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

let prepareSightSafariUrl (result : Route) (apiUrl : string) =
    let mutable sb = StringBuilder(apiUrl)
    sb <- sb.Append("/routes/direct?")
    let nfi = NumberFormatInfo();
    nfi.NumberDecimalSeparator <- ".";
    sb <- sb.AppendFormat("&from={0},{1}",
        result.checkpoints.[0].lattitude.ToString(nfi),
        result.checkpoints.[0].longitude.ToString(nfi))
    let lastPoint = Array.last result.checkpoints
    sb <- sb.AppendFormat("&to={0},{1}",
        lastPoint.lattitude.ToString(nfi),
        lastPoint.longitude.ToString(nfi))
    sb <- sb.Append("&ratio=1&locale=en")
    let intermediatePoints =
        result.checkpoints
        |> Array.skip(1)
        |> Array.take(result.checkpoints.Length - 1)
    sb <- sb.Append("&intermediatePoints=")
    Array.iter(fun (i: Location) ->
        sb <- sb.AppendFormat("{0},{1},",
            i.lattitude.ToString(nfi),
            i.longitude.ToString(nfi))) intermediatePoints
    sb.ToString()