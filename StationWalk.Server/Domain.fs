[<AutoOpen>]
module Domain

open MongoDB.Bson
open System.Text.Json.Serialization

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

[<JsonFSharpConverter>]
type Station = {
    name: string
    branch: Branch
    location: Location
}

type DbStation = {
    _id: BsonObjectId
    name: string
    branch: string
    location: Location
}

[<JsonFSharpConverter>]
type Route = {
    id: string
    name: string
    stationStart: Station
    stationEnd: Station
    checkpoints: Location seq
}

type DbRoute = {
    _id: BsonObjectId
    name: string
    stationStart: Station
    stationEnd: Station
    checkpoints: Location seq
}