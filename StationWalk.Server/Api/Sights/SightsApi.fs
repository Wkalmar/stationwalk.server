module SightsApi

open FSharp.Control.Tasks.V2
open Giraffe
open System.Net.Http
open Newtonsoft.Json

let successCode = 0

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
        let queryResult = ElasticAdapter.getRoute id
        match queryResult with
        | Ok result ->
            let url = prepareSightSafariUrl result SightsConfig.url
            use httpClient = new HttpClient()
            let! dto = getAsync httpClient url |> Async.StartAsTask
            let resp = JsonConvert.DeserializeObject<SightSafariResponse>(dto)
            if resp.code = successCode
            then
                return! text (JsonConvert.SerializeObject resp.body.sightAreas) next httpContext
            else
                return! RequestErrors.BAD_REQUEST "" next httpContext
        | Error _ -> return! ServerErrors.INTERNAL_ERROR "" next httpContext
    }