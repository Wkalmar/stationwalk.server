module AuthApi

open FSharp.Data
open Microsoft.AspNetCore.Http
open FSharp.Control.Tasks.V2.ContextInsensitive
open Giraffe

let authEndpoint = "<your auth endpoint>"

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

