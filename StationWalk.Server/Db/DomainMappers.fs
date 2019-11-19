module DomainMappers

open MongoDB.Bson
open System.Collections.Generic


let private branchFromString s =
    match s with
    | "Red" -> Red
    | "Blue" -> Blue
    | "Green" -> Green
    | _ -> failwith "Failed to parse branch value from string"

let private dbStationToStation (dbStation : MongoModels.Station) (elasticStation : ElasticModels.Station) : Station = 
    let station = {
        id = dbStation._id.ToString()
        name = elasticStation.name.ua
        branch = branchFromString dbStation.branch
        location = dbStation.location
    }
    station

let dbStationsToStations (dbStations, elasticStations : ElasticModels.Station seq) = 
    dbStations     
    |> Array.map(fun i -> dbStationToStation i (Seq.find(fun j -> j.id = i._id.ToString()) elasticStations))
    |> Ok    

let private dbRouteToRoute (dbRoute : MongoModels.Route) : Route =
    let route = {
        id = dbRoute._id.ToString();
        name = dbRoute.name.ua;
        stationStartId =  dbRoute.stationStartId.ToString();
        stationEndId = dbRoute.stationEndId.ToString();
        checkpoints = dbRoute.checkpoints
    }
    route

let dbRoutesToRoutes dbRoutes = 
    dbRoutes
    |> Array.map (fun i -> dbRouteToRoute i)
    |> Ok
    
let routeToDbRoute (route : Route) : MongoModels.Route =
    let dbRoute : MongoModels.Route = {
        _id = BsonObjectId(ObjectId.GenerateNewId())
        name = {
            ua = route.name
            en = route.name
        }
        stationStartId = BsonObjectId(ObjectId(route.stationStartId)) 
        stationEndId = BsonObjectId(ObjectId(route.stationEndId)) 
        checkpoints = route.checkpoints
    }
    dbRoute


