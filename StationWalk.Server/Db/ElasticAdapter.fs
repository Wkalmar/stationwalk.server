module ElasticAdapter

open Nest
open System

let createClient indexName =
    let settings = new ConnectionSettings(Uri("http://localhost:9200"))
    settings.DefaultIndex(indexName) |> ignore
    new ElasticClient(settings)
   
let seedStations (seedStations : ElasticModels.Station array) =
    let client = createClient "stations"
    let response = client.IndexMany(seedStations)
    if response.OriginalException <> null then
        Log.Error response.OriginalException

let getAllStations = 
    let client = createClient "stations"
    let response = client
                    .Search<ElasticModels.Station>
                        (fun (s: SearchDescriptor<ElasticModels.Station>) 
                                -> s.From(Nullable(0))
                                    .Size(Nullable(100))
                                    .MatchAll() :> ISearchRequest)
    if response.OriginalException <> null then
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
    if response.OriginalException <> null then
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
    if response.OriginalException <> null then
        Log.Error response.OriginalException
    response.Documents
    |> Seq.cast<ElasticModels.Route>

let submitRoute (route : ElasticModels.Route) =
    let client = createClient "routes"
    let req = IndexRequest()
    req.Document <- route
    let response = client.Index(req)
    if response.OriginalException <> null then
        Log.Error response.OriginalException

let deleteRoute (id : string) =
    let client = createClient "routes"
    let req = DeleteRequest(IndexName.From("routes"), Id(id))
    let response = client.Delete(req)
    if response.OriginalException <> null then
        Log.Error response.OriginalException
