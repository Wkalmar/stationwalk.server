open Suave
open Suave.Filters
open Suave.Operators
open Suave.Writers
open Suave.Successful
open Newtonsoft.Json
open Suave.CORS

let getRoutes httpContext =
    let result = DAL.getAllRoutes
    Successful.OK (JsonConvert.SerializeObject(result)) httpContext
    
let corsConfig =
    { defaultCORSConfig with allowedUris = InclusiveOption.Some [ "http://localhost:8080" ] }    

let app =
    choose [
        GET >=> choose [
            path "/routes" >=> cors corsConfig >=> getRoutes >=> setMimeType "application/json; charset=utf-8"
        ]
    ]

let serverConfig = 
    { defaultConfig with bindings = [ HttpBinding.createSimple HTTP "127.0.0.1" 8888 ] }

[<EntryPoint>]
let main argv = 
    startWebServer serverConfig app
    0
