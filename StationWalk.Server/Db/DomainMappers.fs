module DomainMappers

open System

let private branchFromString s =
    match s with
    | "Red" -> Red
    | "Blue" -> Blue
    | "Green" -> Green
    | _ -> failwith "Failed to parse branch value from string"

let private dbStationToStation (elasticStation : ElasticModels.Station) : Station = 
    let station = {
        id = elasticStation.id.ToString()
        name = elasticStation.name.ua
        branch = branchFromString elasticStation.branch
        location = {
            lattitude = elasticStation.location.lat
            longitude = elasticStation.location.lon
        }
    }
    station

let dbStationsToStations elasticStations = 
    Seq.map (fun i -> dbStationToStation i) elasticStations   
    |> Array.ofSeq

let private dbRouteToRoute (dbRoute : ElasticModels.Route) : Route =
    let route = {
        id = dbRoute.id;
        name = dbRoute.name.ua;
        stationStartId =  dbRoute.stationStartId.ToString();
        stationEndId = dbRoute.stationEndId.ToString();
        checkpoints = Seq.map (fun (i : ElasticModels.Location) -> {
            lattitude = i.lat
            longitude = i.lon
        }) dbRoute.checkpoints
    }
    route

let dbRoutesToRoutes dbRoutes = 
    dbRoutes
    |> Seq.map (fun i -> dbRouteToRoute i)
    |> Array.ofSeq
    
let routeToDbRoute (route : Route) : ElasticModels.Route =
    let dbRoute : ElasticModels.Route = {
        id = Guid.NewGuid().ToString("N")
        name = {
            ua = route.name
            en = route.name
        }
        stationStartId = route.stationStartId 
        stationEndId = route.stationEndId 
        checkpoints = Seq.map (fun (i : Location) -> {
            lat = i.lattitude
            lon = i.longitude
        }) route.checkpoints
    }
    dbRoute


