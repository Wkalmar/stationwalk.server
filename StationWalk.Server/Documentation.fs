module Documentation

open Giraffe.Swagger.Dsl
open Giraffe.Swagger.Generator
open Giraffe.Swagger.Analyzer
open Giraffe.Swagger.Common

let docAddendums =
    fun (route : RouteInfos) (path : string, verb : HttpVerb, pathDef : PathDefinition) ->
        match path, verb, pathDef with
        | "/", HttpVerb.Get,def ->
            path, verb, { def with OperationId = "Home"; Tags=["home page"] }

        | "/routes", HttpVerb.Get,def ->
            let ndef =
                (def
                    .AddResponse 200 "application/json" "Array of all routes regardless of whether approved or not" typeof<Domain.Route[]>)
            path, verb, ndef
        | "/stations", HttpVerb.Get,def ->
            let ndef =
                (def
                    .AddResponse 200 "application/json" "Array of all stations" typeof<Domain.Station[]>)
            path, verb, ndef
        | "/route", HttpVerb.Post,def ->
            let ndef =
                (def
                    .AddConsume "Route instance" "application/json" Body typeof<Domain.Station>)
                    .AddResponse 200 "application/json" "Empty response and http code" typeof<string>
            path, verb, ndef
        | "/route", HttpVerb.Delete,def ->
            let ndef =
                (def
                    .AddConsume "Route id. You must be authorized to perform this request. Authorization provided via'Authorization' header contining valid JWT token." "application/json" Body typeof<string>)
                    .AddResponse 200 "application/json" "Empty response and http code" typeof<string>
            path, verb, ndef
        | _ -> path,verb,pathDef


let docsConfig c =
    let describeWith desc  =
        { desc
            with
                Title="Kyiv Metro Station Walk"
                Description="This is a REST API for a service aimed at users supplying interesting or scenic routes that start and end with a metro station"
                TermsOfService="Creative commons"
        }

    { c with
        Description = describeWith
        Host = sprintf "/:%d" 5000
        DocumentationAddendums = docAddendums
        MethodCallRules =
            (fun rules ->
                // You can extend quotation expression analysis
                rules.Add ({ ModuleName="App"; FunctionName="httpFailWith" },
                   (fun ctx ->
                       ctx.AddResponse 500 "text/plain" (typeof<string>)
            )))
    }