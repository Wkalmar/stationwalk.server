module JwtValidator

open Microsoft.IdentityModel.Tokens
open System.Text
open System.IdentityModel.Tokens.Jwt
open System

let key = "1ihoqVGfTld2hza4eOtF"

let createValidationParameters =
    let validationParameters = TokenValidationParameters()
    validationParameters.ValidateAudience <- false
    validationParameters.ValidateLifetime <- true
    validationParameters.ValidateIssuer <- false
    validationParameters.IssuerSigningKey <- SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
    validationParameters

let validateToken (token: string) = 
    try
        let tokenHandler = JwtSecurityTokenHandler()
        let validationParameters = createValidationParameters
        let mutable resToken : SecurityToken = null  
        tokenHandler.ValidateToken(token, validationParameters, &resToken)
        |> ignore
        Result.Ok()
    with
    | _ -> Result.Error "Forbidden"