module StationApi

open FSharp.Control.Tasks
open Giraffe

let getAll =
    fun next httpContext ->
    task {
        try
            Log.instance.Debug("Making call to StationApi.getAll")
            let! dbStations = DbAdapter.getAllStations |> Async.StartAsTask
            let result = DbMappers.dbStationsToStations dbStations            
            Log.instance.Debug("Call to StationApi.getAll ended. result: {serialized}", result)
            return! json result next httpContext
        with
        | e -> return Common.logException e
    }