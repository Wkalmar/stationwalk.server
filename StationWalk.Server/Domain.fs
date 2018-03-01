[<AutoOpen>]
module Domain

open MongoDB.Bson
open System

type Location = {
     lattitude: float
     longitude: float
}

type Branch =
    | Red
    | Blue
    | Green

let branchFromString s =
    match s with
    | "Red" -> Red
    | "Blue" -> Blue
    | "Green" -> Green
    | _ -> failwith "Failed to parse branch value from string"


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

let dbStationToStation (dbStation : DbStation) : Station = 
    let station = {
        name = dbStation.name
        branch = branchFromString dbStation.branch
        location = dbStation.location
    }
    station

let stationToDbStation (station : Station) : DbStation = 
    let dbStation = {
        _id = BsonObjectId(ObjectId.GenerateNewId())
        name = station.name
        branch = station.branch.ToString()
        location = station.location
    }
    dbStation

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