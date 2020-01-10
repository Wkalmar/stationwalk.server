module ElasticModels

open Nest

[<GeoPoint>]
type Location = {
    lat: float
    lon: float
}

type Station = {
    id: string
    name: LocalizableString
    location: Location
    branch: string
}

type Route = {
    id: string
    name: LocalizableString
    stationStartId: string
    stationEndId: string
    checkpoints: Location seq
}