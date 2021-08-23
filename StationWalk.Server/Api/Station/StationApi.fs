module StationApi

open FSharp.Control.Tasks.V2
open Giraffe
open System.Text.Json

let getAll =
    fun next httpContext ->
    task {
        Log.instance.Debug("Making call to StationApi.getAll")
        let! dbStations = DbAdapter.getAllStations |> Async.StartAsTask
        let result = DbMappers.dbStationsToStations dbStations
        let serialized = JsonSerializer.Serialize(result, Common.serializerOptions)
        Log.instance.Debug("Call to StationApi.getAll ended. result: {serialized}", serialized)
        return! text serialized next httpContext
    }