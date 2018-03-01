module DAL

open MongoDB.Driver

let private connectionString = "<Your connection string>"
let private client = new MongoClient(connectionString)
let private db = client.GetDatabase("<your db>")

let private routes = db.GetCollection<DbRoute> "Routes"
let private stations = db.GetCollection<DbStation> "Stations"

let getAllRoutes =
    let filter = FilterDefinition.Empty
    let allDbRoutes = 
        routes.Find(filter).ToListAsync()
        |> Async.AwaitTask
        |> Async.RunSynchronously
    allDbRoutes.ToArray()
        |> Array.map (fun i -> dbRouteToRoute i)

let getAllStations = 
    let filter = FilterDefinition.Empty
    let allDbStations = 
        stations.Find(filter).ToListAsync()
        |> Async.AwaitTask
        |> Async.RunSynchronously
    allDbStations.ToArray()
        |> Array.map (fun i -> dbStationToStation i)

let seedStations (seedStations : Station array) =
    let filter = FilterDefinition.Empty
    stations.DeleteMany(filter) |> ignore
    seedStations
        |> Array.map (fun i -> stationToDbStation i)
        |> stations.InsertMany
        |> ignore
    (seedStations) |> ignore