module SightsApi

open System.Text
open FSharp.Control.Tasks.V2
open Giraffe
open System.Net.Http
open System.Globalization
open Newtonsoft.Json

//todo move
let successCode = 0

type SightDto = {
    name: string
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

let getAsync (client:HttpClient) (url:string) =
    async {
        let! response = client.GetAsync(url) |> Async.AwaitTask
        response.EnsureSuccessStatusCode () |> ignore
        let! content = response.Content.ReadAsStringAsync() |> Async.AwaitTask
        return content
    }

let getSights id =
    fun next httpContext ->
    task {
        let result = ElasticAdapter.getRoute id
        //todo extract and test
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
        use httpClient = new HttpClient()
        let url = sb.ToString()
        let! dto = getAsync httpClient url |> Async.StartAsTask
        let resp = JsonConvert.DeserializeObject<SightSafariResponse>(dto)
        if resp.code = successCode
        then
            return! text (JsonConvert.SerializeObject resp) next httpContext
        else
            return! RequestErrors.BAD_REQUEST "" next httpContext
    }