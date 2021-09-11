module RouteApi

open FSharp.Control.Tasks.V2.ContextInsensitive
open Giraffe
open System.Text.Json
open Microsoft.AspNetCore.Http

let getAll =
    fun next httpContext ->
    task {
        try 
            Log.instance.Debug("Making call to RouteApi.getAll")
            let! routes = DbAdapter.getAllRoutes |> Async.StartAsTask
            let result = DbMappers.dbRoutesToRoutes routes
            let serialized = JsonSerializer.Serialize(result, Common.serializerOptions)
            Log.instance.Debug("Call to RouteApi.delete ended. result {getAll}", serialized)
            return! text serialized next httpContext
        with
        | e -> return Common.logException e
    }

let submit =
    fun next (httpContext : HttpContext) ->
    task {
        try
            let! body = httpContext.ReadBodyFromRequestAsync()
            Log.instance.Debug("Making call to RouteApi.submit. body: {body}", body)
            let route = Common.fromJson<Route> body
            let dbRoute = DbMappers.routeToDbRoute route
            do! DbAdapter.submitRoute dbRoute |> Async.StartAsTask
            Log.instance.Debug("Call to RouteApi.submit ended")
            return! text "" next httpContext
        with
        | e -> return Common.logException e
    }

let delete (id: string) =
    fun (next: HttpFunc) (httpContext : HttpContext) ->
    Log.instance.Debug("Making call to RouteApi.delete. id: {id}", id)
    let result =
        AuthApi.authorize httpContext
        |> Result.map (fun _ -> DbAdapter.deleteRoute id)
    Log.instance.Debug("Call to RouteApi.delete ended. result {result}", result)
    match result with
    | Ok _ -> text "" next httpContext
    | Error "Forbidden" -> RequestErrors.FORBIDDEN "" next httpContext
    | Error _ -> ServerErrors.INTERNAL_ERROR "" next httpContext