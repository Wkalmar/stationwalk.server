[<AutoOpen>]
module Domain

open System.Text.Json.Serialization
open Nest

[<JsonFSharpConverter>]
type Location = {
     lattitude: float
     longitude: float
}

[<JsonFSharpConverter(JsonUnionEncoding.BareFieldlessTags)>]
type Branch =
    | Red
    | Blue
    | Green

type LocalizableString = {
    [<SearchAsYouType>]
    en: string
    [<SearchAsYouType>]
    ua: string
}

[<JsonFSharpConverter>]
type Station = {
    id: string
    name: string
    branch: Branch
    location: Location
}

[<JsonFSharpConverter>]
type Route = {
    id: string
    name: string
    stationStartId: string 
    stationEndId: string
    checkpoints: Location seq
}