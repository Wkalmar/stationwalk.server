﻿namespace StationWalk.Server.UnitTests

open FsCheck.Xunit
open RouteModels

module RemoveRedundantCheckpointsTests =

    let ``result array contains no more than 5 items`` input mapFn =
        let res = mapFn input
        Array.length res <= 5

    [<Property>]
    let maxLength x =
        ``result array contains no more than 5 items`` x removeRedundantCheckpoints

    let ``result contains first point from input`` (input: Location[]) (mapFn : Location[] -> Location[]) =
        if Array.length input = 0 then
            true
        else
            let res = mapFn input
            res.[0] = input.[0]

    [<Property>]
    let firstItem x =
        ``result contains first point from input`` x removeRedundantCheckpoints

    let ``result contains last point from input`` (input: Location[]) (mapFn : Location[] -> Location[]) =
        if Array.length input = 0 then
            true
        else
            let res = mapFn input
            res.[res.Length-1] = input.[input.Length-1]

    [<Property>]
    let lastItem x =
        ``result contains last point from input`` x removeRedundantCheckpoints

    let ``result contains only points from input`` input mapFn =
        let res = mapFn input
        Array.length (Array.except input res) = 0

    [<Property>]
    let onlyInput x =
        ``result contains only points from input`` x removeRedundantCheckpoints
