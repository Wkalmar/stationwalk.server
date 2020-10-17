module DomainMappers

open System
open Domain
open ElasticModels

let private branchFromString s =
    match s with
    | "Red" -> Red
    | "Blue" -> Blue
    | "Green" -> Green
    | _ -> failwith "Failed to parse branch value from string"

let private dbStationToStation (elasticStation : ElasticModels.Station) =
    let station : Domain.Station = {
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
    Seq.map (dbStationToStation) elasticStations
    |> Array.ofSeq

let private dbRouteToRoute (dbRoute : ElasticModels.Route) =
    let route : Domain.Route = {
        id = dbRoute.id;
        name = dbRoute.name.ua;
        stationStartId =  dbRoute.stationStartId.ToString();
        stationEndId = dbRoute.stationEndId.ToString();
        checkpoints = Array.map (fun (i) -> {
            lattitude = i.lat
            longitude = i.lon
        }) dbRoute.checkpoints
    }
    route

let dbRoutesToRoutes dbRoutes =
    dbRoutes
    |> Seq.map (fun i -> dbRouteToRoute i)
    |> Array.ofSeq

type CheckPointExtendedInfo = {
    index : int
    checkPoint: ElasticModels.Location
    distanceToNextCheckPoint: float
}

let removeRedundantCheckpoints (checkPoints : ElasticModels.Location[]) =
    let checkPointsMaxCount = 5
    let euclidianDistance c1 c2 =
        Math.Pow(float(c1.lat - c2.lat), float(2)) + Math.Pow(float(c1.lon - c2.lon), float(2))
    if checkPoints.Length <= 5 then
        checkPoints
    else
        checkPoints
        |> Array.mapi(fun i c ->
            if i = 0 || i = checkPoints.Length - 1 then
                {
                    index = i
                    checkPoint = c
                    distanceToNextCheckPoint = float(1000000)
                }
            else
                {
                    index = i
                    checkPoint = c
                    distanceToNextCheckPoint = euclidianDistance checkPoints.[i+1] c
                }
        )
        |> Array.sortByDescending(fun i -> i.distanceToNextCheckPoint)
        |> Array.take(checkPointsMaxCount)
        |> Array.sortBy(fun i -> i.index)
        |> Array.map(fun i -> i.checkPoint)

let routeToDbRoute (route : Domain.Route) =
    let mappedCheckpoints =
        route.checkpoints
        |> Array.map (fun (i) -> {
            lat = i.lattitude
            lon = i.longitude
        })
        |> removeRedundantCheckpoints
    {
        id = Guid.NewGuid().ToString("N")
        name = {
            ua = route.name
            en = route.name
        }
        stationStartId = route.stationStartId
        stationEndId = route.stationEndId
        checkpoints = mappedCheckpoints
    }
