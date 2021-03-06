module SightsTests

open Xunit

[<Fact>]
let prepateSightSafariUrl() =
    let route : ElasticModels.Route = {
        name = {
            en = "obolo embarkment"
            ua = "obolon embarkment"
        }
        stationStartId = "5c2e1d0c867a6335386700eb"
        checkpoints = [|
            {
                lon = 30.498056M
                lat = 50.501111M
            }
            {
                lon = 30.503239631652836M
                lat = 50.501122690981326M
            }
            {
                lon = 30.509419441223148M
                lat = 50.506033012426734M
            }
            {
                lon = 30.526456832885746M
                lat = 50.48873550116753M
            }
            {
                lon = 30.49813270568848M
                lat = 50.48636137365777M
            }
        |]
        stationEndId = "5c2e1d0c867a6335386700ec"
        id = "a111a511f4ac4dc5863cb2e3cb215ee4"
    }
    let url = prepareSightSafariUrl route "https://sightsafari.city/api/v1"
    Assert.Equal("https://sightsafari.city/api/v1/routes/direct?&from=50.501111,30.498056&to=50.48636137365777,30.49813270568848&ratio=1&locale=en&intermediatePoints=50.501122690981326,30.503239631652836,50.506033012426734,30.509419441223148,50.48873550116753,30.526456832885746,50.48636137365777,30.49813270568848,", url)