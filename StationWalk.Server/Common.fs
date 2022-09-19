module Common

open System
open System.Text.Json
open System.Text.Json.Serialization
open System.Runtime.ExceptionServices
open MongoDB.Bson

let serializerOptions = JsonSerializerOptions()
serializerOptions.DefaultIgnoreCondition <- JsonIgnoreCondition.WhenWritingNull

let fromJson<'a> (json : string) =
  JsonSerializer.Deserialize<'a>(json, serializerOptions)

type Exception with
    member this.Reraise () =
        (ExceptionDispatchInfo.Capture this).Throw ()
        Unchecked.defaultof<_>

let logException (e: Exception) =
    Log.instance.Error("Error {e}", e)
    e.Reraise()

let generateId =
    BsonObjectId(ObjectId.GenerateNewId())

let generateStringId =
    generateId.ToString()