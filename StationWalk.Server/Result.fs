module Result

let bindArg binder x result = match result with Error e -> Error e | Ok _ -> binder x