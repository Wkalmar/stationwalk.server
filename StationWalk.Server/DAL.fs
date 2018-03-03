module DAL

open MongoDB.Driver

let private connectionString = "<Your connection string>"
let private client = new MongoClient(connectionString)
let private db = client.GetDatabase("<your db>")

let private routes = db.GetCollection<DbRoute> "Routes"
let private stations = db.GetCollection<DbStation> "Stations"

let getAllRoutes() =
    try
        let filter = FilterDefinition.Empty
        let allDbRoutes = 
            routes.Find(filter).ToListAsync()
            |> Async.AwaitTask
            |> Async.RunSynchronously
        Success(allDbRoutes.ToArray())
    with
    | ex -> Failure ex.Message

let getAllStations() = 
    try
        let filter = FilterDefinition.Empty
        let allDbStations = 
            stations.Find(filter).ToListAsync()
            |> Async.AwaitTask
            |> Async.RunSynchronously
        Success(allDbStations.ToArray())
    with
    | ex -> Failure ex.Message

let seedStations (seedStations : Station array) =
    let filter = FilterDefinition.Empty
    stations.DeleteMany(filter) |> ignore
    seedStations
        |> Array.map (fun i -> DomainMappers.stationToDbStation i)
        |> stations.InsertMany
        |> ignore
    (seedStations) |> ignore