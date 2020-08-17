module ElasticModels

open Nest

[<GeoPoint>]
type Location = {
    lat: decimal
    lon: decimal
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
    checkpoints: Location[]
}