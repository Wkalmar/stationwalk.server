module DAL

open MongoDB.Driver

let private connectionString = "<Your connection string>"
let private client = new MongoClient(connectionString)
let private db = client.GetDatabase("<your db>")

let private routes = db.GetCollection<DbRoute> "Routes"
let private stations = db.GetCollection<DbStation> "Stations"

let getAllRoutes() = async { 
    try
        let filter = FilterDefinition.Empty 
        let! allDbRoutes = 
            routes.Find(filter).ToListAsync()  
            |> Async.AwaitTask  
        return Ok(allDbRoutes.ToArray()) 
    with 
    | ex -> return Error ex.Message 
} 
let getAllStations() = async {
    try
        let filter = FilterDefinition.Empty
        let! allDbStations = 
            stations.Find(filter).ToListAsync()
            |> Async.AwaitTask            
        return Ok(allDbStations.ToArray())
    with
    | ex -> return Error ex.Message
}

let seedStations (seedStations : Station array) =
    let filter = FilterDefinition.Empty
    stations.DeleteMany(filter) |> ignore
    seedStations
        |> Array.map (DomainMappers.stationToDbStation)
        |> stations.InsertMany
        |> ignore
    (seedStations) |> ignore