module DomainMappers

open MongoDB.Bson


let private branchFromString s =
    match s with
    | "Red" -> Red
    | "Blue" -> Blue
    | "Green" -> Green
    | _ -> failwith "Failed to parse branch value from string"

let private dbStationToStation (dbStation : DbStation) : Station = 
    let station = {
        name = dbStation.name
        branch = branchFromString dbStation.branch
        location = dbStation.location
    }
    station

let dbStationsToStations dbStations = 
    dbStations 
    |> Array.map(fun i -> dbStationToStation i)
    |> Ok    

let stationToDbStation (station : Station) : DbStation = 
    let dbStation = {
        _id = BsonObjectId(ObjectId.GenerateNewId())
        name = station.name
        branch = station.branch.ToString()
        location = station.location
    }
    dbStation

let private dbRouteToRoute (dbRoute : DbRoute) : Route =
    let route = {
        id = dbRoute._id.ToString();
        name = dbRoute.name;
        stationStart = dbRoute.stationStart;
        stationEnd = dbRoute.stationEnd;
        checkpoints = dbRoute.checkpoints
    }
    route

let dbRoutesToRoutes dbRoutes = 
    dbRoutes
    |> Array.map (fun i -> dbRouteToRoute i)
    |> Ok
    
let routeToDbRoute (route : Route) : DbRoute =
    let dbRoute = {
        _id = BsonObjectId(ObjectId.GenerateNewId())
        name = route.name
        stationStart = route.stationStart
        stationEnd = route.stationEnd
        checkpoints = route.checkpoints
    }
    dbRoute


