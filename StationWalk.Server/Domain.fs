[<AutoOpen>]
module Domain

open MongoDB.Bson
open System

type Location = {
     lattitude: float
     longitude: float
}

type Branch =
    | Red
    | Blue
    | Green

type Station = {
    name: string
    branch: Branch
    location: Location
}

type DbStation = {
    _id: BsonObjectId
    name: string
    branch: string
    location: Location
}

type Route = {
    id: string
    name: string
    stationStart: Station
    stationEnd: Station
    checkpoints: Location seq
}

type DbRoute = {
    _id: BsonObjectId
    name: string
    stationStart: Station
    stationEnd: Station
    checkpoints: Location seq
}