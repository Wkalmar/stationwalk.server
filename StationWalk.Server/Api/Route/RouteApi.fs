module RouteApi

open FSharp.Control.Tasks
open Giraffe
open Microsoft.AspNetCore.Http

let getAll page =
    fun next httpContext ->
    task {
        try             
            let calculatePaging page =
                let pageSize = 10
                (page-1)*pageSize, pageSize
            let (skip, take) = calculatePaging page
            Log.instance.Debug("Making call to RouteApi.getAll")
            let! routes = DbAdapter.getAllRoutes skip take |> Async.StartAsTask
            let domainRoutes = DbMappers.dbRoutesToRoutes routes
            let result = RouteModels.toFullRoutes domainRoutes 
            Log.instance.Debug("Call to RouteApi.delete ended. result {getAll}", result)
            return! json result next httpContext            
        with
        | e -> return Common.logException e
    }

let getApproved =
    fun next httpContext ->
    task {
        try             
            Log.instance.Debug("Making call to RouteApi.getApproved")
            let! routes = DbAdapter.getApprovedRoutes |> Async.StartAsTask
            let domainRoutes = DbMappers.dbRoutesToRoutes routes
            let result = RouteModels.toShortRoutes domainRoutes
            Log.instance.Debug("Call to RouteApi.delete ended. result {getAll}", result)
            return! json result next httpContext            
        with
        | e -> return Common.logException e
    }

let submit =
    fun next (httpContext : HttpContext) ->
    task {
        try
            let! body = httpContext.ReadBodyFromRequestAsync()
            Log.instance.Debug("Making call to RouteApi.submit. body: {body}", body)
            let apiRoute = Common.fromJson<RouteModels.ShortRoute> body
            let route = RouteModels.fromShortRoute apiRoute
            let dbRoute = DbMappers.routeToDbRoute route
            do! DbAdapter.createRoute dbRoute |> Async.StartAsTask
            Log.instance.Debug("Call to RouteApi.submit ended")
            return! text "" next httpContext
        with
        | e -> return Common.logException e
    }

let update = 
    fun next (httpContext : HttpContext) ->
    task {
        try
            let! body = httpContext.ReadBodyFromRequestAsync()
            Log.instance.Debug("Making call to RouteApi.update. body: {body}", body)
            let parseBodyAndUpdate b =
                let apiRoute = Common.fromJson<RouteModels.FullRoute> b
                let route = RouteModels.fromFullRoute apiRoute
                let dbRoute = DbMappers.routeToDbRoute route
                DbAdapter.updateRoute dbRoute |> Async.StartAsTask
            let result =
                AuthApi.authorize httpContext
                |> Result.map (fun _ -> parseBodyAndUpdate body)
            Log.instance.Debug("Call to RouteApi.update ended")
            match result with
            | Ok _ -> return! text "" next httpContext
            | Error "Forbidden" -> return! RequestErrors.FORBIDDEN "" next httpContext
            | Error _ -> return! ServerErrors.INTERNAL_ERROR "" next httpContext          
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