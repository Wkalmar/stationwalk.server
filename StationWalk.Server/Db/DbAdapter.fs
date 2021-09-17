module DbAdapter

open MongoDB.Driver
open MongoDB.Bson
open System
open System.Runtime.ExceptionServices

let private connectionString = DbConfig.connectionString
let private client = MongoClient(connectionString)
let private dbName = DbConfig.dbName
let private db = client.GetDatabase(dbName)

let private routes = db.GetCollection<DbModels.Route> "Routes"
let private stations = db.GetCollection<DbModels.Station> "Stations"

let getAllRoutes (skip:int) (take:int) = async {
    try
        let filter = FilterDefinition.Empty
        let! allDbRoutes =
            routes
                .Find(filter)
                .SortBy(fun p -> p.id :> obj)
                .Skip(skip)
                .Limit(take)
                .ToListAsync()
            |> Async.AwaitTask
        return allDbRoutes.ToArray()
    with
    | e -> return Common.logException e
}

let getApprovedRoutes = async {
    try
        let! allDbRoutes =
            routes
                .Find(fun p -> p.approved)
                .ToListAsync()
            |> Async.AwaitTask
        return allDbRoutes.ToArray()
    with
    | e -> return Common.logException e
}

let createRoute (route : DbModels.Route) = async {
    try
        let! insertResult =
            routes.InsertOneAsync(route)
            |> Async.AwaitTask
        return insertResult
    with
    | e -> return Common.logException e
}

let deleteRoute (id:string) =
    routes.DeleteOne(fun i -> i.id = BsonObjectId(ObjectId(id)) )

let getAllStations = async {
    try
        let filter = FilterDefinition.Empty
        let! allDbStations =
            stations.Find(filter).ToListAsync()
            |> Async.AwaitTask
        return allDbStations.ToArray()
    with
    | e -> return Common.logException e
}

let seedStations (seedStations : DbModels.Station array) =
    try
        let filter = FilterDefinition.Empty
        stations.DeleteMany(filter) |> ignore
        seedStations
            |> stations.InsertMany
            |> ignore
    with
    | e -> Common.logException e