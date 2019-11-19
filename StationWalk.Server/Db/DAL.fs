module DAL

open MongoDB.Driver
open MongoDB.Bson

let private connectionString = "<Your connection string>"
let private client = new MongoClient(connectionString)
let private db = client.GetDatabase("<your db>")

let private routes = db.GetCollection<MongoModels.Route> "Routes"
let private stations = db.GetCollection<MongoModels.Station> "Stations"

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

let submitRoute (route : Route) = async {
    try
        let dbRoute = DomainMappers.routeToDbRoute route
        let! insertResult = 
            routes.InsertOneAsync(dbRoute)
            |> Async.AwaitTask
        return Ok(insertResult)
    with
    | ex -> return Error ex.Message 
}

let deleteRoute (id:string) = 
    try
        let result = routes.DeleteOne(fun i -> i._id = BsonObjectId(ObjectId(id)) )
        if result.DeletedCount = int64(1) then
            Ok()
        else Error "ItemNotFound"
    with
    | ex -> Error ex.Message

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

let seedStations (seedStations : MongoModels.Station array) =
    let filter = FilterDefinition.Empty
    stations.DeleteMany(filter) |> ignore
    seedStations        
        |> stations.InsertMany
        |> ignore
    (seedStations) |> ignore