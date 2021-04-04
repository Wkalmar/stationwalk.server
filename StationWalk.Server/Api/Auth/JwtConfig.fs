module JwtConfig

open dotenv.net.Utilities

let private envReader = EnvReader()

let salt = envReader.GetStringValue("STATIONWALK.AUTH.SALT")
let authEndpoint = envReader.GetStringValue("STATIONWALK.AUTH.ENDPOINT")

