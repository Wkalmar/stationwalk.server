module Common

open System
open System.Text.Json
open System.Runtime.ExceptionServices

let serializerOptions = JsonSerializerOptions()
serializerOptions.IgnoreNullValues <- true

let fromJson<'a> (json : string) =
  JsonSerializer.Deserialize<'a>(json, serializerOptions)

type Exception with
    member this.Reraise () =
        (ExceptionDispatchInfo.Capture this).Throw ()
        Unchecked.defaultof<_>

let logException (e: Exception) =
    Log.instance.Error("Error {e}", e)
    e.Reraise()