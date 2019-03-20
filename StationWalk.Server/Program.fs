open Giraffe
open FSharp.Control.Tasks.V2.ContextInsensitive
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Newtonsoft.Json
open System

let getRoutes = 
    fun next httpContext ->
    task {
    let! routes = DAL.getAllRoutes()
    let result = 
        routes
        |> Result.bind DomainMappers.dbRoutesToRoutes  
    
    match result with
    | Ok s -> return! json (JsonConvert.SerializeObject(s)) next httpContext
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
    | Ok s -> return! json (JsonConvert.SerializeObject(s)) next httpContext
    | Error f -> return! ServerErrors.INTERNAL_ERROR (f) next httpContext
}

let fromJson<'a> json =
  JsonConvert.DeserializeObject(json, typeof<'a>) :?> 'a

let submitRoute = 
    fun next (httpContext : Microsoft.AspNetCore.Http.HttpContext) ->
    task {
    let! route = httpContext.BindJsonAsync<Route>()
    let! result = DAL.submitRoute route
    match result with
    | Ok _ -> return! text "" next httpContext
    | Error f -> return! ServerErrors.INTERNAL_ERROR (f) next httpContext
}

    
let app : HttpHandler =
    choose [
        OPTIONS >=> Successful.OK ""
        GET >=> choose [
            route "/routes" >=> getRoutes
            route "/stations" >=> getStations
        ]        
        POST >=> choose [
            route "/route" >=> submitRoute 
        ]
    ]

let configureApp (appBuilder : IApplicationBuilder) =
    appBuilder.UseGiraffe app

let configureServices (services : IServiceCollection) =
    // Add Giraffe dependencies
    services.AddGiraffe() |> ignore

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
