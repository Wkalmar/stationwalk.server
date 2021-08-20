module DbMappers

open MongoDB.Bson

let private branchFromString s =
    match s with
    | "Red" -> Red
    | "Blue" -> Blue
    | "Green" -> Green
    | _ -> failwith "Failed to parse branch value from string"

let private dbStationToStation (dbStation : DbModels.Station) : Station =
    let station = {
        id = dbStation.id.ToString()
        name = dbStation.name.ua
        branch = branchFromString dbStation.branch
        location = {
            lattitude = dbStation.location.lat
            longitude = dbStation.location.lon
        }
    }
    station

let dbStationsToStations dbStations =
    dbStations
    |> Array.map(fun i -> dbStationToStation i)
    |> Ok

let stationToDbStation (station : Station) : DbModels.Station =
    let dbStation : DbModels.Station = {
        id = BsonObjectId(ObjectId.GenerateNewId())
        name = {
            ua = station.name
            en = ""
        }
        branch = station.branch.ToString()
        location = {
            lat = station.location.lattitude
            lon = station.location.longitude
        }
    }
    dbStation

let private dbRouteToRoute (dbRoute : DbModels.Route) : Route =
    let route = {
        id = dbRoute.id.ToString()
        name = dbRoute.name.ua
        description = dbRoute.description.ua
        stationStartId = dbRoute.stationStartId
        stationEndId = dbRoute.stationEndId
        checkpoints = Array.map (fun (i : DbModels.Location) -> {
            lattitude = i.lat
            longitude = i.lon
        }) dbRoute.checkpoints
        approved = dbRoute.approved
    }
    route

let dbRoutesToRoutes dbRoutes =
    dbRoutes
    |> Array.map (fun i -> dbRouteToRoute i)
    |> Ok

let routeToDbRoute (route : Route) : DbModels.Route =
    let dbRoute : DbModels.Route = {
        id = BsonObjectId(ObjectId.GenerateNewId())
        name = {
            ua = route.name
            en = ""
        }
        description = {
            ua = route.description
            en = ""
        }
        stationStartId = route.stationStartId
        stationEndId = route.stationEndId
        checkpoints = Array.map (fun (i) -> {
            lat = i.lattitude
            lon = i.longitude
        }) route.checkpoints
        approved = route.approved
    }
    dbRoute


