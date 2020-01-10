module StationApi

open FSharp.Control.Tasks.V2
open Giraffe
open System.Text.Json

let getAll = 
    fun next httpContext ->
    task {
        let elasticStations = ElasticAdapter.getAllStations
        match elasticStations with    
        | Ok e -> 
            let result = DomainMappers.dbStationsToStations e        
            return! text (JsonSerializer.Serialize(result, Common.serializerOptions)) next httpContext
        | _ -> return! ServerErrors.INTERNAL_ERROR "" next httpContext
    }

let searchStation queryString =
    fun next httpContext ->
    task {
        let elasticStations = ElasticAdapter.searchStation queryString
        match elasticStations with    
        | Ok e -> 
            let result = DomainMappers.dbStationsToStations e        
            return! text (JsonSerializer.Serialize(result, Common.serializerOptions)) next httpContext
        | _ -> return! ServerErrors.INTERNAL_ERROR "" next httpContext
    }