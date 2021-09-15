module DbModels

open MongoDB.Bson

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