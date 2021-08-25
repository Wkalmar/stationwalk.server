module Log

open Serilog
open Serilog.Formatting.Json

let instance =
    LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.LiterateConsole()
        .WriteTo.File(JsonFormatter(), "log/log.txt")
        .CreateLogger()

