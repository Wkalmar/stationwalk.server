module MongoModels

open MongoDB.Bson

type Station = {
    _id: BsonObjectId    
    branch: string
    location: Location
}

type Route = {
    _id: BsonObjectId
    name: LocalizableString
    stationStartId: BsonObjectId
    stationEndId: BsonObjectId
    checkpoints: Location seq
}

