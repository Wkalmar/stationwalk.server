module DbModels

open MongoDB.Bson

type LocalizableString = {
    en: string
    ua: string
}

type Location = {
    lat: decimal
    lon: decimal
}

type Station = {
    id: BsonObjectId
    name: LocalizableString
    location: Location
    branch: string
}

type Route = {
    id: BsonObjectId
    name: LocalizableString
    stationStartId: string
    stationEndId: string
    checkpoints: Location[]
    approved: bool
    description: LocalizableString
}