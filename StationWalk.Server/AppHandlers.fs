module AppHandlers

open Giraffe
open System
open Microsoft.Extensions.Logging

let getRoutes  = 
    fun next httpContext ->
    let result = DAL.getAllRoutes >-> DomainMappers.dbRoutesToRoutes 
    match result() with
    | Success s -> json s next httpContext
    | Failure _ -> setStatusCode 500 next httpContext
    

let getStations =
    fun next httpContext ->
    let result = DAL.getAllStations >-> DomainMappers.dbStationsToStations
    match result() with
    | Success s -> json s next httpContext
    | Failure _ -> setStatusCode 500 next httpContext
    
let app:HttpHandler =
    choose [
        GET >=> choose [
            route "/routes" >=> getRoutes
            route "/stations" >=> getStations
        ]
    ]

let errorHandler(ex : Exception) (logger : ILogger) =
    logger.LogError(EventId(), ex, "An unhandled exception has occurred while executing the request.")
    clearResponse >=> setStatusCode 500 >=> text ex.Message