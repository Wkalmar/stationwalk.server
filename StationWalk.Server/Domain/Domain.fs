[<AutoOpen>]
module Domain

open System.Text.Json.Serialization

type LocalizableString = {
    en: string
    ua: string
}

[<JsonFSharpConverter>]
type Location = {
     lattitude: decimal
     longitude: decimal
}

[<JsonFSharpConverter(JsonUnionEncoding.BareFieldlessTags)>]
type Branch =
    | Red
    | Blue
    | Green

[<JsonFSharpConverter>]
type Station = {
    id: string
    name: LocalizableString
    branch: Branch
    location: Location
}

type Route = {
    id: string
    name: LocalizableString
    stationStartId: string
    stationEndId: string
    checkpoints: Location[]
    approved: bool
    description: LocalizableString
}