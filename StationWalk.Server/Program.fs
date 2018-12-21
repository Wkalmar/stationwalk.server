open Suave
open Suave.Filters
open Suave.Operators
open Suave.Writers
open Newtonsoft.Json
open Suave.CORS

let getRoutes httpContext = async {
    let! routes = DAL.getAllRoutes()
    let result = 
        routes
        |> Result.bind DomainMappers.dbRoutesToRoutes  
    
    match result with
    | Ok s -> return! Successful.OK (JsonConvert.SerializeObject(s)) httpContext
    | Error f -> return! ServerErrors.INTERNAL_ERROR (f) httpContext
}
    

let getStations httpContext = async {
    let! stations = DAL.getAllStations() 
    let result =
        stations
        |> Result.bind DomainMappers.dbStationsToStations    
    match result with
    | Ok s -> return! Successful.OK (JsonConvert.SerializeObject(s)) httpContext
    | Error f -> return! ServerErrors.INTERNAL_ERROR (f) httpContext
}

let fromJson<'a> json =
  JsonConvert.DeserializeObject(json, typeof<'a>) :?> 'a

let getResourceFromReq<'a> req =
  let getString rawForm =
    System.Text.Encoding.UTF8.GetString(rawForm)

  req.rawForm 
  |> getString 
  |> fromJson<'a>

let submitRoute req httpContext = async {
    let route = getResourceFromReq req
    let! result = DAL.submitRoute route
    match result with
    | Ok _ -> return! Successful.OK "" httpContext
    | Error f -> return! ServerErrors.INTERNAL_ERROR (f) httpContext
}

    
let corsConfig =
    { defaultCORSConfig with allowedUris = InclusiveOption.Some [ "http://localhost:8080" ] }    

let app =
    choose [
        OPTIONS >=> cors corsConfig >=> Successful.OK ""
        GET >=> choose [
            path "/routes" >=> cors corsConfig >=> getRoutes >=> setMimeType "application/json; charset=utf-8"
            path "/stations" >=> cors corsConfig >=> getStations >=> setMimeType "application/json; charset=utf-8"
        ]        
        POST >=> choose [
            path "/route" >=> cors corsConfig >=> request (submitRoute) 
        ]
    ]

let serverConfig = 
    { defaultConfig with bindings = [ HttpBinding.createSimple HTTP "127.0.0.1" 8888 ] }

[<EntryPoint>]
let main argv = 
    //SeedStations.seed
    startWebServer serverConfig app
    0
