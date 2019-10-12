open Giraffe
open FSharp.Control.Tasks.V2.ContextInsensitive
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open System
open System.Text.Json

let getRoutes = 
    fun next httpContext ->
    task {
    let! routes = DAL.getAllRoutes()
    let result = 
        routes
        |> Result.bind DomainMappers.dbRoutesToRoutes  
    
    match result with
    | Ok s -> return! text (JsonSerializer.Serialize(s)) next httpContext
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
    | Ok s -> return! text (JsonSerializer.Serialize(s)) next httpContext
    | Error f -> return! ServerErrors.INTERNAL_ERROR (f) next httpContext
}

let fromJson<'a> (json : string) =
  JsonSerializer.Deserialize<'a>(json)

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
            route "/" >=> htmlFile "client/dist/index.html"
        ]        
        POST >=> choose [
            route "/route" >=> submitRoute 
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
