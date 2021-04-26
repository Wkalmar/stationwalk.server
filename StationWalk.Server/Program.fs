open dotenv.net
open Giraffe
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open System

let app : HttpHandler =
    choose [
        OPTIONS >=> Successful.OK ""
        GET >=> choose [
            route "/routes" >=> RouteApi.getAll
            route "/stations" >=> StationApi.getAll
            routef "/station/%s" StationApi.searchStation
            routef "/sights/%s" SightsApi.getSights
            route "/" >=> htmlFile "client/dist/index.html"
        ]
        POST >=> choose [
            route "/route" >=> RouteApi.submit
            route "/auth" >=> AuthApi.login
        ]
        DELETE >=> choose [
            routef "/route/%s" RouteApi.delete
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
    //SeedStations.seed |> ignore
    try
        DotEnv.Config(true)
        WebHostBuilder()
            .UseKestrel()
            .Configure(Action<IApplicationBuilder> configureApp)
            .ConfigureServices(configureServices)
            .Build()
            .Run()
    with
    | e -> Log.Exception(e)
    0
