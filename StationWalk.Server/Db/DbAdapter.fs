module DbAdapter

open MongoDB.Driver
open MongoDB.Bson

let private connectionString = DbConfig.connectionString
let private client = MongoClient(connectionString)
let private dbName = DbConfig.dbName
let private db = client.GetDatabase(dbName)

let private routes = db.GetCollection<DbModels.Route> "Routes"
let private stations = db.GetCollection<DbModels.Station> "Stations"

let getAllRoutes = async {
    let filter = FilterDefinition.Empty
    let! allDbRoutes =
        routes.Find(filter).ToListAsync()
        |> Async.AwaitTask
    return allDbRoutes.ToArray()
}

let submitRoute (route : DbModels.Route) = async {
    let! insertResult =
        routes.InsertOneAsync(route)
        |> Async.AwaitTask
    return insertResult
}

let deleteRoute (id:string) =
    routes.DeleteOne(fun i -> i.id = BsonObjectId(ObjectId(id)) )

let getAllStations = async {
    let filter = FilterDefinition.Empty
    let! allDbStations =
        stations.Find(filter).ToListAsync()
        |> Async.AwaitTask
    return allDbStations.ToArray()
}

let seedStations (seedStations : DbModels.Station array) =
    let filter = FilterDefinition.Empty
    stations.DeleteMany(filter) |> ignore
    seedStations
        |> stations.InsertMany
        |> ignore
    (seedStations) |> ignore