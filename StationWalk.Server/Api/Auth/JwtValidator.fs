﻿module JwtValidator

open Microsoft.IdentityModel.Tokens
open System.Text
open System.IdentityModel.Tokens.Jwt
open System

let createValidationParameters =
    let validationParameters = TokenValidationParameters()
    validationParameters.ValidateAudience <- false
    validationParameters.ValidateLifetime <- true
    validationParameters.ValidateIssuer <- false
    validationParameters.IssuerSigningKey <- SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfig.salt))
    validationParameters.ClockSkew <- TimeSpan.Zero    
    validationParameters

let validateToken (token: string) = 
    try
        let tokenHandler = JwtSecurityTokenHandler()
        let validationParameters = createValidationParameters
        let mutable resToken : SecurityToken = null  
        tokenHandler.ValidateToken(token, validationParameters, &resToken)
        |> ignore
        Ok()
    with
    | _ -> Error "Forbidden"