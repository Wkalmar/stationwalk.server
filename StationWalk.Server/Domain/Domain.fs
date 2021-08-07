[<AutoOpen>]
module Domain

open System.Text.Json.Serialization

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
    checkpoints: Location[]
    approved: bool
    description: string
}