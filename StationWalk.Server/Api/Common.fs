module Common

open System.Text.Json

let serializerOptions = JsonSerializerOptions()
serializerOptions.IgnoreNullValues <- true

let fromJson<'a> (json : string) =
  JsonSerializer.Deserialize<'a>(json, serializerOptions)