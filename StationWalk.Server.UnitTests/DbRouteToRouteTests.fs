module DbRouteToRouteTests

open DbMappers
open Domain
open DbModels

open MongoDB.Bson
open Xunit

[<Fact>]
let sussessPath() =
    let input : DbModels.Route = {
        id = BsonObjectId(ObjectId("4c2e1d0c867a6335386700ef"))
        name = {
            en = "Sagaydachnogo pedestrian walk"
            ua = "Sagaydachnogo pedestrian walk"
        }
        stationStartId = "5c2e1d0c867a6335386700ef"
        stationEndId = "5c2e1d0c867a6335386700ee"
        approved = false
        description = {
            en = "Lots of restaraunts"
            ua = "Lots of restaraunts"
        }
        checkpoints = [|
            {
                lat = 50.465M
                lon = 30.516667M }
            {
                lat = 50.46450370786999M
                lon = 30.51834583282471M }
            {
                lat = 50.46292015790519M
                lon = 30.519118309021M }
            {
                lat = 50.46166420126396M
                lon = 30.520834922790527M }
            {
                lat = 50.4610908186649M
                lon = 30.521693229675297M }
            {
                lat = 50.459479849401035M
                lon = 30.524268150329593M }
            {
                lat = 50.45871530241579M
                lon = 30.525426864624027M }
            {
                lat = 50.45896105100877M
                lon = 30.525684356689457M }
        |]
    }
    let res = dbRouteToRoute input
    Assert.Equal("4c2e1d0c867a6335386700ef", res.id)
    Assert.Equal("Sagaydachnogo pedestrian walk", res.name)
    Assert.Equal("5c2e1d0c867a6335386700ef", res.stationStartId)
    Assert.Equal("5c2e1d0c867a6335386700ee", res.stationEndId)
    Assert.Equal<Domain.Location>([|
        {
            lattitude = 50.465M
            longitude = 30.516667M }
        {
            lattitude = 50.46450370786999M
            longitude = 30.51834583282471M }
        {
            lattitude = 50.46292015790519M
            longitude = 30.519118309021M }
        {
            lattitude = 50.4610908186649M
            longitude = 30.521693229675297M }
        {
            lattitude = 50.45896105100877M
            longitude = 30.525684356689457M }
    |], res.checkpoints)