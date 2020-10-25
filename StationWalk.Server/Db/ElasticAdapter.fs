module ElasticAdapter

open Nest
open System
open Elasticsearch.Net
open Newtonsoft.Json

type GetByIdResponse<'a> = {
    _source: 'a
}

let connectionPool = new SniffingConnectionPool([| Uri("http://localhost:9200") |])
let config = new ConnectionConfiguration(connectionPool)
let lowLevelClient = ElasticLowLevelClient(config)

let createClient indexName =
    let settings = new ConnectionSettings(Uri("http://localhost:9200"))
    settings.DefaultIndex(indexName) |> ignore
    ElasticClient(settings)

let seedStations (seedStations : ElasticModels.Station array) =
    let client = createClient "stations"
    let response = client.IndexMany(seedStations)
    if not (isNull response.OriginalException) then
        Log.Error response.OriginalException

let getAllStations =
    let client = createClient "stations"
    let response = client
                    .Search<ElasticModels.Station>
                        (fun (s: SearchDescriptor<ElasticModels.Station>)
                                -> s.From(Nullable(0))
                                    .Size(Nullable(100))
                                    .MatchAll() :> ISearchRequest)
    if not (isNull response.OriginalException) then
        Log.Error response.OriginalException
    response.Documents
    |> Seq.cast<ElasticModels.Station>

let searchStation queryString =
    let client = createClient "stations"
    let response = client
                    .Search<ElasticModels.Station>
                        (fun (s: SearchDescriptor<ElasticModels.Station>)
                                -> s.From(Nullable(0))
                                    .Size(Nullable(3))
                                    .Query(fun q ->
                                        q.MultiMatch(fun mm ->
                                            mm.Query(queryString)
                                                .Type(Nullable(TextQueryType.BoolPrefix))
                                                .Fields(fun f ->
                                                    f.Field(fun ff -> ff.name.en)
                                                        .Field(fun ff -> ff.name.en.Suffix("_2gram"))
                                                        .Field(fun ff -> ff.name.en.Suffix("_3gram"))
                                                        .Field(fun ff -> ff.name.ua)
                                                        .Field(fun ff -> ff.name.ua.Suffix("_2gram"))
                                                        .Field(fun ff -> ff.name.ua.Suffix("_3gram")) :> IPromise<Fields>)
                                            :> IMultiMatchQuery))
                                    :> ISearchRequest)
    if not (isNull response.OriginalException) then
        Log.Error response.OriginalException
    response.Documents
    |> Seq.cast<ElasticModels.Station>

let getAllRoutes =
    let client = createClient "routes"
    let response = client
                    .Search<ElasticModels.Route>
                        (fun (s: SearchDescriptor<ElasticModels.Route>)
                                -> s.From(Nullable(0))
                                    .Size(Nullable(1000))
                                    .MatchAll() :> ISearchRequest)
    if not (isNull response.OriginalException) then
        Log.Error response.OriginalException
    response.Documents
    |> Seq.cast<ElasticModels.Route>

let getRoute (id: string) =
    let path = String.Format("routes/_doc/{0}", id)
    let response = lowLevelClient.DoRequest<StringResponse>(HttpMethod.GET, path, null, null)
    JsonConvert.DeserializeObject<GetByIdResponse<ElasticModels.Route>>(response.Body)._source

let submitRoute (route : ElasticModels.Route) =
    let path = String.Format("routes/_doc/{0}", route.id)
    let body = PostData.op_Implicit(JsonConvert.SerializeObject(route))
    lowLevelClient.DoRequest<StringResponse>(HttpMethod.PUT, path, body, null)

let deleteRoute (id : string) =
    let client = createClient "routes"
    let req = DeleteRequest(IndexName.From("routes"), Id(id))
    let response = client.Delete(req)
    if not (isNull response.OriginalException) then
        Log.Error response.OriginalException
