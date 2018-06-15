module Setup

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Logging
open Giraffe
open System
open System.IO

let configureApp (app : IApplicationBuilder) =
    app.UseGiraffeErrorHandler(AppHandlers.errorHandler)
        .UseStaticFiles()
        .UseGiraffe(AppHandlers.app)

let configureServices (services : IServiceCollection) =
   services.AddGiraffe() |> ignore

let configureLogging (builder : ILoggingBuilder) =
    let filter (l : LogLevel) = l.Equals LogLevel.Error
    builder.AddFilter(filter).AddConsole().AddDebug() |> ignore

let configureAppConfiguration (_ : WebHostBuilderContext) (builder : IConfigurationBuilder) =
    builder.AddEnvironmentVariables() |> ignore

type LambdaEntryPoint() =
    inherit Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction()

    override this.Init(builder : IWebHostBuilder) =
        let contentRoot = Directory.GetCurrentDirectory()
        
        builder
            .UseContentRoot(contentRoot) 
            .Configure(Action<IApplicationBuilder> configureApp)
            .ConfigureServices(configureServices)
            |> ignore


[<EntryPoint>]
let main _ =
    let contentRoot = Directory.GetCurrentDirectory()
    let webRoot     = Path.Combine(contentRoot, "WebRoot")
    WebHostBuilder()
        .UseKestrel()
        .UseContentRoot(contentRoot)
        .UseIISIntegration()
        .UseWebRoot(webRoot)
        .ConfigureAppConfiguration(Action<WebHostBuilderContext, IConfigurationBuilder> configureAppConfiguration)
        .Configure(Action<IApplicationBuilder> configureApp)
        .ConfigureServices(configureServices)
        .ConfigureLogging(configureLogging)
        .Build()
        .Run()
    0