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
                        .Search<ElasticModels.Station>(fun (s: SearchDescriptor<ElasticModels.Station>) -> s.From(Nullable(0))
                                                                                                            .Size(Nullable(100))
                                                                                                            .MatchAll() :> ISearchRequest)
        response.Documents
        |> Seq.cast<ElasticModels.Station>
        |> Ok
    with ex -> Error ex.Message