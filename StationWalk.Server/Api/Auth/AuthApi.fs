module AuthApi

open Microsoft.AspNetCore.Http
open Giraffe

let authorize (httpContext : HttpContext) =    
    let authorizationHeader = httpContext.GetRequestHeader "Authorization"
    let authorizationResult = 
        authorizationHeader
        |> Result.bind JwtValidator.validateToken
    authorizationResult

