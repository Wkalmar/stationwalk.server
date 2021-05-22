module ElasticModels

open Nest

type LocalizableString = {
    [<SearchAsYouType>]
    en: string
    [<SearchAsYouType>]
    ua: string
}

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