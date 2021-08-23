module StationApi

open FSharp.Control.Tasks.V2
open Giraffe
open System.Text.Json

let getAll =
    fun next httpContext ->
    task {
        let! dbStations = DbAdapter.getAllStations |> Async.StartAsTask
        let result = DbMappers.dbStationsToStations dbStations
        return! text (JsonSerializer.Serialize(result, Common.serializerOptions)) next httpContext
    }