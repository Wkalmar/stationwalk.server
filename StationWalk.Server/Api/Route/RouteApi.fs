module RouteApi

open FSharp.Control.Tasks.V2.ContextInsensitive
open Giraffe
open System.Text.Json
open Microsoft.AspNetCore.Http

let getAll =
    fun next httpContext ->
    task {
        let routes = ElasticAdapter.getAllRoutes
        let result = DomainMappers.dbRoutesToRoutes routes
        return! text (JsonSerializer.Serialize(result, Common.serializerOptions)) next httpContext
    }

let submit =
    fun next (httpContext : HttpContext) ->
    task {
        let! body = httpContext.ReadBodyFromRequestAsync()
        let route = Common.fromJson<Route> body
        let dbRoute = DomainMappers.routeToDbRoute route
        let insertResult = ElasticAdapter.submitRoute dbRoute
        match insertResult with
        | Ok _ -> return! text "" next httpContext
        | Error _ -> return! ServerErrors.INTERNAL_ERROR "" next httpContext
    }

let delete (id: string) =
    fun (next: HttpFunc) (httpContext : HttpContext) ->
    let result =
        AuthApi.authorize httpContext
        |> Result.map (fun _ -> ElasticAdapter.deleteRoute id)
    match result with
    | Ok _ -> text "" next httpContext
    | Error "Forbidden" -> RequestErrors.FORBIDDEN "" next httpContext
    | Error _ -> ServerErrors.INTERNAL_ERROR "" next httpContext