module ElasticAdapter

open Nest
open System

let createClient =
    let settings = new ConnectionSettings(Uri("http://localhost:9200"))
    settings.DefaultIndex("stations") |> ignore
    ElasticClient(settings)
   
let seedStations (seedStations : ElasticModels.Station array) =
    let client = createClient
    client.IndexMany(seedStations)

let getAllStations = 
    try
        let client = createClient
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
        let client = createClient
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