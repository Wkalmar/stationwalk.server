module DbConfig

open dotenv.net.Utilities

let private envReader = EnvReader()

let connectionString = envReader.GetStringValue("STATIONWALK_DB_CONNECTION")
let dbName = envReader.GetStringValue("STATIONWALK_DB_NAME")