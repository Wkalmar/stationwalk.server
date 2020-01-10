module ElasticAdapter

open Nest
open System

let createClient indexName =
    let settings = new ConnectionSettings(Uri("http://localhost:9200"))
    settings.DefaultIndex(indexName) |> ignore
    ElasticClient(settings)
   
let seedStations (seedStations : ElasticModels.Station array) =
    let client = createClient "stations"
    client.IndexMany(seedStations)

let getAllStations = 
    try
        let client = createClient "stations"
        let response = client
                        .Search<ElasticModels.Station>
                            (fun (s: SearchDescriptor<ElasticModels.Station>) 
                                    -> s.From(Nullable(0))
                                        .Size(Nullable(100))
                                        .MatchAll() :> ISearchRequest)
        response.Documents
        |> Seq.cast<ElasticModels.Station>
        |> Ok
    with ex -> Error ex.Message

let searchStation queryString =
    try
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
        response.Documents
        |> Seq.cast<ElasticModels.Station>
        |> Ok
    with ex -> Error ex.Message

let getAllRoutes = 
    try
        let client = createClient "routes"
        let response = client
                        .Search<ElasticModels.Route>
                            (fun (s: SearchDescriptor<ElasticModels.Route>) 
                                    -> s.From(Nullable(0))
                                        .Size(Nullable(1000))
                                        .MatchAll() :> ISearchRequest)
        response.Documents
        |> Seq.cast<ElasticModels.Route>
        |> Ok
    with ex -> Error ex.Message

let submitRoute (route : ElasticModels.Route) =
    try
        let client = createClient "routes"
        let req = IndexRequest()
        req.Document <- route
        let response = client.Index(req)
        match response.Result with
        | Result.Error -> Error response.ServerError.Error.StackTrace 
        | _ -> Ok()
    with ex -> Error ex.Message    

let deleteRoute (id : string) =
    try
        let client = createClient "routes"
        let req = DeleteRequest(IndexName.From("routes"), Id(id))
        let response = client.Delete(req)
        match response.Result with
        | Result.Error -> Error response.ServerError.Error.StackTrace 
        | _ -> Ok()
    with ex -> Error ex.Message    