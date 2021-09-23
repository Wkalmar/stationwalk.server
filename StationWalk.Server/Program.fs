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
            routef "/routes/%i" RouteApi.getAll
            route "/approvedroutes" >=> RouteApi.getApproved
            route "/stations" >=> StationApi.getAll
            route "/health" >=> Successful.OK "healthy"
            route "/" >=> htmlFile "Client/dist/index.html"
        ]
        POST >=> choose [
            route "/route" >=> RouteApi.submit
        ]
        PUT >=> choose [
            route "/route" >=> RouteApi.update
        ]
        DELETE >=> choose [
            routef "/route/%s" RouteApi.delete
        ]
    ]

let configureApp (appBuilder : IApplicationBuilder) =
    appBuilder.UseGiraffe app
    appBuilder.UseStaticFiles() |> ignore
    appBuilder.UseSpaStaticFiles()
    appBuilder.UseSpa(fun spa -> spa.Options.SourcePath <- "Client/dist")

let configureServices (services : IServiceCollection) =
    services.AddGiraffe() |> ignore
    services.AddSpaStaticFiles(fun configuration -> configuration.RootPath <- "Client/dist")

[<EntryPoint>]
let main argv =
    try
        DotEnv.Config(false)
        //SeedStations.seed |> ignore
        WebHostBuilder()
            .UseKestrel()
            .Configure(Action<IApplicationBuilder> configureApp)
            .ConfigureServices(configureServices)
            .Build()
            .Run()
    with
    | e -> Log.instance.Error("Exception occured. {e}", e)
    0
