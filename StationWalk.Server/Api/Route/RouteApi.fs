module RouteApi

open FSharp.Control.Tasks.V2.ContextInsensitive
open Giraffe
open System.Text.Json
open Microsoft.AspNetCore.Http

let getAll = 
    fun next httpContext ->
    task {
        let routes = ElasticAdapter.getAllRoutes
        match routes with
        | Ok s -> 
            let result = DomainMappers.dbRoutesToRoutes s
            return! text (JsonSerializer.Serialize(result, Common.serializerOptions)) next httpContext
        | Error f -> return! ServerErrors.INTERNAL_ERROR (f) next httpContext
    }

let submit = 
    fun next (httpContext : HttpContext) ->
    task {    
        let! body = httpContext.ReadBodyFromRequestAsync()
        let route = Common.fromJson<Route> body
        let dbRoute = DomainMappers.routeToDbRoute route
        let result = ElasticAdapter.submitRoute dbRoute
        match result with
        | Ok _ -> return! text "" next httpContext
        | Error f -> return! ServerErrors.INTERNAL_ERROR (f) next httpContext
    }

let delete (id: string) =
    fun (next: HttpFunc) (httpContext : HttpContext) ->
    let result = 
        AuthApi.authorize httpContext
        |> Result.bind (fun _ -> ElasticAdapter.deleteRoute id)
    match result with
    | Ok _ -> text "" next httpContext
    | Error "ItemNotFound" -> RequestErrors.BAD_REQUEST "" next httpContext
    | Error "Forbidden" -> RequestErrors.FORBIDDEN "" next httpContext
    | Error _ -> ServerErrors.INTERNAL_ERROR "" next httpContext
    
