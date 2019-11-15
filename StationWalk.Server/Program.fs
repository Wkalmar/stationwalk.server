﻿open Giraffe
open FSharp.Control.Tasks.V2.ContextInsensitive
open FSharp.Data
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open System
open System.Text.Json
open Microsoft.AspNetCore.Http

let authEndpoint = "<your auth endpoint>"

let serializerOptions = JsonSerializerOptions()
serializerOptions.IgnoreNullValues <- true

let getRoutes = 
    fun next httpContext ->
    task {
    let! routes = DAL.getAllRoutes()
    let result = 
        routes
        |> Result.bind DomainMappers.dbRoutesToRoutes  
    
    match result with
    | Ok s -> return! text (JsonSerializer.Serialize(s, serializerOptions)) next httpContext
    | Error f -> return! ServerErrors.INTERNAL_ERROR (f) next httpContext
}
    

let getStations = 
    fun next httpContext ->
    task {
    let! stations = DAL.getAllStations() 
    let result =
        stations
        |> Result.bind DomainMappers.dbStationsToStations    
    match result with
    | Ok s -> return! text (JsonSerializer.Serialize(s, serializerOptions)) next httpContext
    | Error f -> return! ServerErrors.INTERNAL_ERROR (f) next httpContext
}

let fromJson<'a> (json : string) =
  JsonSerializer.Deserialize<'a>(json, serializerOptions)

let submitRoute = 
    fun next (httpContext : HttpContext) ->
    task {    
    let! body = httpContext.ReadBodyFromRequestAsync()
    let route = fromJson<Route> body
    let! result = DAL.submitRoute route
    match result with
    | Ok _ -> return! text "" next httpContext
    | Error f -> return! ServerErrors.INTERNAL_ERROR (f) next httpContext
}

let login = 
    fun next (httpContext : HttpContext) ->
    task {    
    let! body = httpContext.ReadBodyFromRequestAsync()
    let response = Http.Request(authEndpoint, httpMethod = "POST", body = TextRequest body)
    match response.StatusCode, response.Body with
    | 200, Text t -> return! text t next httpContext
    | _, _ -> return! RequestErrors.FORBIDDEN "" next httpContext
}

let authorize (httpContext : HttpContext) =    
    let authorizationHeader = httpContext.GetRequestHeader "Authorization"
    let authorizationResult = 
        authorizationHeader
        |> Result.bind JwtValidator.validateToken
    authorizationResult

let deleteRoute (id: string) =
    fun (next: HttpFunc) (httpContext : HttpContext) ->
    let result = 
        authorize httpContext
        |> Result.bind (fun _ -> DAL.deleteRoute id)
    match result with
    | Ok _ -> text "" next httpContext
    | Error "ItemNotFound" -> RequestErrors.BAD_REQUEST "" next httpContext
    | Error "Forbidden" -> RequestErrors.FORBIDDEN "" next httpContext
    | Error _ -> ServerErrors.INTERNAL_ERROR "" next httpContext
        

let app : HttpHandler =
    choose [
        OPTIONS >=> Successful.OK ""
        GET >=> choose [
            route "/routes" >=> getRoutes
            route "/stations" >=> getStations
            route "/" >=> htmlFile "client/dist/index.html"
        ]        
        POST >=> choose [
            route "/route" >=> submitRoute 
            route "/auth" >=> login
        ]
        DELETE >=> choose [
            routef "/route/%s" deleteRoute
        ]
    ]

let configureApp (appBuilder : IApplicationBuilder) =
    appBuilder.UseGiraffe app
    appBuilder.UseStaticFiles() |> ignore
    appBuilder.UseSpaStaticFiles()
    appBuilder.UseSpa(fun spa -> spa.Options.SourcePath <- "client/dist")

let configureServices (services : IServiceCollection) =     
    services.AddGiraffe() |> ignore
    services.AddSpaStaticFiles(fun configuration -> configuration.RootPath <- "client/dist")

[<EntryPoint>]
let main argv = 
    //SeedStations.seed
    WebHostBuilder()
        .UseKestrel()
        .Configure(Action<IApplicationBuilder> configureApp)
        .ConfigureServices(configureServices)
        .Build()
        .Run()
    0
