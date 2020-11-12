module Log

open Serilog
open Serilog.Formatting.Json

let Error (msg : string) =
    use logger =
          LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.LiterateConsole()
            .WriteTo.RollingFile(JsonFormatter(), "log-{Date}.log")
            .CreateLogger()
    logger.Error(msg)

let Exception (ex : exn) =
    use logger =
          LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.LiterateConsole()
            .WriteTo.RollingFile(JsonFormatter(), "log-{Date}.log")
            .CreateLogger()
    logger.Error(ex, "")