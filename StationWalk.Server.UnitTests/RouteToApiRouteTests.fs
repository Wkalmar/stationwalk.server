module RouteToApiRouteTests

open Xunit

[<Fact>]
let toShortRoute() =
    let input : Domain.Route = {
        id = "4c2e1d0c867a6335386700ef"
        name = {
            en = "Sagaydachnogo pedestrian walk"
            ua = "Пішохідна вулиця Сагайдачного"
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
                lattitude = 50.465M
                longitude = 30.516667M }
            {
                lattitude = 50.46450370786999M
                longitude = 30.51834583282471M }
            {
                lattitude = 50.46292015790519M
                longitude = 30.519118309021M }
            {
                lattitude = 50.46166420126396M
                longitude = 30.520834922790527M }
            {
                lattitude = 50.4610908186649M
                longitude = 30.521693229675297M }
            {
                lattitude = 50.459479849401035M
                longitude = 30.524268150329593M }
            {
                lattitude = 50.45871530241579M
                longitude = 30.525426864624027M }
            {
                lattitude = 50.45896105100877M
                longitude = 30.525684356689457M }
        |]
    }
    let res = RouteModels.toShortRoute input
    Assert.Equal("4c2e1d0c867a6335386700ef", res.id)
    Assert.Equal("Sagaydachnogo pedestrian walk", res.name.en)
    Assert.Equal("Пішохідна вулиця Сагайдачного", res.name.ua)
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

[<Fact>]
let toFullRoute() =
    let input : Domain.Route = {
        id = "4c2e1d0c867a6335386700ef"
        name = {
            en = "Sagaydachnogo pedestrian walk"
            ua = "Пішохідна вулиця Сагайдачного"
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
                lattitude = 50.465M
                longitude = 30.516667M }
            {
                lattitude = 50.46450370786999M
                longitude = 30.51834583282471M }
            {
                lattitude = 50.46292015790519M
                longitude = 30.519118309021M }
            {
                lattitude = 50.46166420126396M
                longitude = 30.520834922790527M }
            {
                lattitude = 50.4610908186649M
                longitude = 30.521693229675297M }
            {
                lattitude = 50.459479849401035M
                longitude = 30.524268150329593M }
            {
                lattitude = 50.45871530241579M
                longitude = 30.525426864624027M }
            {
                lattitude = 50.45896105100877M
                longitude = 30.525684356689457M }
        |]
    }
    let res = RouteModels.toFullRoute input
    Assert.Equal("4c2e1d0c867a6335386700ef", res.id)
    Assert.Equal("Sagaydachnogo pedestrian walk", res.name.en)
    Assert.Equal("Пішохідна вулиця Сагайдачного", res.name.ua)
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
            lattitude = 50.46166420126396M
            longitude = 30.520834922790527M }
        {
            lattitude = 50.4610908186649M
            longitude = 30.521693229675297M }
        {
            lattitude = 50.459479849401035M
            longitude = 30.524268150329593M }
        {
            lattitude = 50.45871530241579M
            longitude = 30.525426864624027M }
        {
            lattitude = 50.45896105100877M
            longitude = 30.525684356689457M }
    |], res.checkpoints)