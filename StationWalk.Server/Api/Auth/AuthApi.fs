module AuthApi

open Microsoft.AspNetCore.Http
open Giraffe

let authorize (httpContext : HttpContext) =
    let authorizationHeader = httpContext.GetRequestHeader "Authorization"
    match authorizationHeader with
    | Ok token -> JwtValidator.validateToken token
    | Error _ -> Error "Forbidden"

