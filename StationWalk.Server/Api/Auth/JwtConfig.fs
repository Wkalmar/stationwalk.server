module JwtConfig

open dotenv.net.Utilities

let private envReader = EnvReader()

let salt = envReader.GetStringValue("STATIONWALK.AUTH.SALT")

