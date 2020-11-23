[<AutoOpen>]
module Sights

open System.Text
open System.Globalization

type SightDto = {
    name: string
    localizedName: string
    links: string array
    imageLink: string
}

type SightSafariResponseBody = {
    sightAreas: SightDto array
}

type SightSafariResponse = {
    code: int
    description: string
    body: SightSafariResponseBody
}

let prepareSightSafariUrl (result : ElasticModels.Route) =
    let mutable sb = StringBuilder("https://sightsafari.city/api/v1/routes/direct?")
    let nfi = NumberFormatInfo();
    nfi.NumberDecimalSeparator <- ".";
    sb <- sb.AppendFormat("&from={0},{1}",
        result.checkpoints.[0].lat.ToString(nfi),
        result.checkpoints.[0].lon.ToString(nfi))
    let lastPoint = Array.last result.checkpoints
    sb <- sb.AppendFormat("&to={0},{1}",
        lastPoint.lat.ToString(nfi),
        lastPoint.lon.ToString(nfi))
    sb <- sb.Append("&ratio=1&locale=en")
    let intermediatePoints =
        result.checkpoints
        |> Array.skip(1)
        |> Array.take(result.checkpoints.Length - 1)
    sb <- sb.Append("&intermediatePoints=")
    Array.iter(fun (i: ElasticModels.Location) ->
        sb <- sb.AppendFormat("{0},{1},",
            i.lat.ToString(nfi),
            i.lon.ToString(nfi))) intermediatePoints
    sb.ToString()