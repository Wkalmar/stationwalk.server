module RouteModels

open System
open System.Text.Json.Serialization

[<JsonFSharpConverter>]
type FullRoute = {
    id: string
    name: LocalizableString
    stationStartId: string
    stationEndId: string
    checkpoints: Location[]
    approved: bool
    description: LocalizableString
}

[<JsonFSharpConverter>]
type ShortRoute = {
    id: string
    name: LocalizableString
    stationStartId: string
    stationEndId: string
    checkpoints: Location[]    
    description: LocalizableString
}

type CheckPointExtendedInfo = {
    index : int
    checkPoint: Location
    distanceToNextCheckPoint: float
}

let removeRedundantCheckpoints (checkPoints : Location[]) =
    let checkPointsMaxCount = 5
    let euclidianDistance c1 c2 =
        Math.Pow(float(c1.lattitude - c2.lattitude), float(2)) + Math.Pow(float(c1.longitude - c2.longitude), float(2))
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

let toShortRoute (route: Domain.Route) : ShortRoute = 
    let route = {
        id = route.id.ToString()
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
            |> Array.map (fun (i : Domain.Location) -> {
                lattitude = i.lattitude
                longitude = i.longitude
            })
            |> removeRedundantCheckpoints        
    }
    route

let toFullRoute (route: Domain.Route) : FullRoute = 
    let route = {
        id = route.id.ToString()
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
            |> Array.map (fun (i : Domain.Location) -> {
                lattitude = i.lattitude
                longitude = i.longitude
            })
        approved = route.approved
    }
    route

let toShortRoutes routes = 
    routes
    |> Seq.map(fun i -> toShortRoute i)    

let toFullRoutes routes = 
    routes
    |> Seq.map(fun i -> toFullRoute i)