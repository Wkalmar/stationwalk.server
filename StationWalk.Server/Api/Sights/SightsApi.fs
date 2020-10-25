module SightsApi
open FSharp.Control.Tasks.V2
open Giraffe

let getSights id =
    fun next httpContext ->
    task {
        let result = ElasticAdapter.getRoute id
        return! text "kek" next httpContext
    }