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
        name = {
            ua = dbStation.name.ua
            en = dbStation.name.en
        } 
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

let stationToDbStation (station : Station) : DbModels.Station =
    let dbStation : DbModels.Station = {
        id = BsonObjectId(ObjectId.GenerateNewId())
        name = {
            ua = station.name.ua
            en = station.name.en
        }
        branch = station.branch.ToString()
        location = {
            lat = station.location.lattitude
            lon = station.location.longitude
        }
    }
    dbStation

let dbRouteToRoute (dbRoute : DbModels.Route) : Route =
    let route = {
        id = dbRoute.id.ToString()
        name = {
            ua = dbRoute.name.ua
            en = dbRoute.name.en
        } 
        description = {
            ua = dbRoute.description.ua
            en = dbRoute.description.en
        } 
        stationStartId = dbRoute.stationStartId
        stationEndId = dbRoute.stationEndId
        checkpoints =
            dbRoute.checkpoints
            |> Array.map (fun (i : DbModels.Location) -> {
                lattitude = i.lat
                longitude = i.lon
            })
        approved = dbRoute.approved
    }
    route

let dbRoutesToRoutes dbRoutes =
    dbRoutes
    |> Array.map (fun i -> dbRouteToRoute i)

let routeToDbRoute (route : Route) : DbModels.Route =
    let dbRoute : DbModels.Route = {
        id = BsonObjectId(ObjectId.Parse(route.id))
        name = {
            ua = route.name.ua
            en = route.name.en
        }
        description = {
            ua = route.description.ua
            en = route.description.en
        }
        stationStartId = route.stationStartId
        stationEndId = route.stationEndId
        checkpoints =
            route.checkpoints
            |> Array.map (fun i ->
                {
                    lat = i.lattitude
                    lon = i.longitude
                })
        approved = route.approved
    }
    dbRoute
