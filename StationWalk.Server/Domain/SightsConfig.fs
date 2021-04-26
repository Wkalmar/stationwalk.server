module SightsConfig

open dotenv.net.Utilities

let private envReader = EnvReader()

let url = envReader.GetStringValue("STATIONWALK_SIGHTS_API")