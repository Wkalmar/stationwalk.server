module Log

open Serilog
open Serilog.Formatting.Json

let instance =
    LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.LiterateConsole()
        .WriteTo.RollingFile(JsonFormatter(), "log-{Date}.log")
        .CreateLogger()

