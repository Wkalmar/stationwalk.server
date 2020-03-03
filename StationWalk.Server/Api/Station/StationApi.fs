module StationApi

open FSharp.Control.Tasks.V2
open Giraffe
open System.Text.Json

let getAll = 
    fun next httpContext ->
    task {
        let elasticStations = ElasticAdapter.getAllStations
        let result = DomainMappers.dbStationsToStations elasticStations
        return! text (JsonSerializer.Serialize(result, Common.serializerOptions)) next httpContext
    }

let searchStation queryString =
    fun next httpContext ->
    task {
        let elasticStations = ElasticAdapter.searchStation queryString
        let result = DomainMappers.dbStationsToStations elasticStations
        return! text (JsonSerializer.Serialize(result, Common.serializerOptions)) next httpContext
    }