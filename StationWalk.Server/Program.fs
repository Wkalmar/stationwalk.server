open Suave
open Suave.Filters
open Suave.Operators
open Suave.Writers
open Suave.Successful
open Suave.ServerErrors
open Newtonsoft.Json
open Suave.CORS

let getRoutes httpContext =
    let result = DAL.getAllRoutes >-> DomainMappers.dbRoutesToRoutes 
    match result() with
    | Success s -> Successful.OK (JsonConvert.SerializeObject(s)) httpContext
    | Failure f -> ServerErrors.INTERNAL_ERROR (f) httpContext
    

let getStations httpContext =
    let result = DAL.getAllStations >-> DomainMappers.dbStationsToStations
    match result() with
    | Success s -> Successful.OK (JsonConvert.SerializeObject(s)) httpContext
    | Failure f -> ServerErrors.INTERNAL_ERROR (f) httpContext
    
let corsConfig =
    { defaultCORSConfig with allowedUris = InclusiveOption.Some [ "http://localhost:8080" ] }    

let app =
    choose [
        GET >=> choose [
            path "/routes" >=> cors corsConfig >=> getRoutes >=> setMimeType "application/json; charset=utf-8"
            path "/stations" >=> cors corsConfig >=> getStations >=> setMimeType "application/json; charset=utf-8"
        ]
    ]

let serverConfig = 
    { defaultConfig with bindings = [ HttpBinding.createSimple HTTP "127.0.0.1" 8888 ] }

[<EntryPoint>]
let main argv = 
    //SeedStations.seed
    startWebServer serverConfig app
    0
