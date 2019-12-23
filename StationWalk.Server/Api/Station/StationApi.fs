module StationApi

open FSharp.Control.Tasks.V2
open Giraffe
open System.Text.Json

let getAll = 
    fun next httpContext ->
    task {
        let! stations = DAL.getAllStations() 
        let elasticStations = ElasticAdapter.getAllStations
        match stations, elasticStations with    
        | Ok s, Ok e -> 
            let result = DomainMappers.dbStationsToStations (s, e)        
            match result with
            | Ok s -> return! text (JsonSerializer.Serialize(s, Common.serializerOptions)) next httpContext
            | Error f -> return! ServerErrors.INTERNAL_ERROR (f) next httpContext
        | _, _ -> return! ServerErrors.INTERNAL_ERROR "" next httpContext
    }

let searchStation queryString =
    fun next httpContext ->
    task {
        let! stations = DAL.getAllStations() 
        let elasticStations = ElasticAdapter.searchStation queryString
        match stations, elasticStations with    
        | Ok s, Ok e -> 
            let result = DomainMappers.dbStationsToStations (s, e)        
            match result with
            | Ok s -> return! text (JsonSerializer.Serialize(s, Common.serializerOptions)) next httpContext
            | Error f -> return! ServerErrors.INTERNAL_ERROR (f) next httpContext
        | _, _ -> return! ServerErrors.INTERNAL_ERROR "" next httpContext
    }