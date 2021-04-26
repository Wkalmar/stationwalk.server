module Log

open Serilog
open Serilog.Formatting.Json

let private createLogger =
    LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.LiterateConsole()
        .WriteTo.RollingFile(JsonFormatter(), "log-{Date}.log")
        .CreateLogger()

let Error (msg : string) =
    use logger = createLogger
    logger.Error(msg)

let Exception (ex : exn) =
    use logger = createLogger
    logger.Error(ex, "")