module ElasticConfig

open dotenv.net.Utilities

let private envReader = EnvReader()

let elasticUrl = envReader.GetStringValue("STATIONWALK_ELASTIC_URL")