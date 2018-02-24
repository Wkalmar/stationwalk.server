[<AutoOpen>]
module Domain

open MongoDB.Bson
open MongoDB.Bson

type Location = {
     lattitude: float
     longitude: float
}

type Station = {
    name: string
    location: Location
}

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

let dbRouteToRoute (dbRoute : DbRoute) : Route =
    let route = {
        id = dbRoute._id.ToString();
        name = dbRoute.name;
        stationStart = dbRoute.stationStart;
        stationEnd = dbRoute.stationEnd;
        checkpoints = dbRoute.checkpoints
    }
    route