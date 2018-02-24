module DAL

open MongoDB.Driver

let private connectionString = "<Your connection string>"
let private client = new MongoClient(connectionString)
let private db = client.GetDatabase("<your db>")

let private routes = db.GetCollection<DbRoute> "Routes"

let getAllRoutes =
    let filter = FilterDefinition.Empty
    let allDbRoutes = 
        routes.Find(filter).ToListAsync()
                  |> Async.AwaitTask
                  |> Async.RunSynchronously
    allDbRoutes.ToArray()
        |> Array.map (fun i -> dbRouteToRoute i)

