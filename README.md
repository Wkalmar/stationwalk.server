## Kyiv station walk
This project is Kyiv's clone of [London station walk](http://www.nationalparkcity.london/station_walks).
It is supposed to be non-profit project so I do not intend to violate copyright if there is any. In case of any legal issues feel free to contact me.
## Using .NET Core
As it is .NET core project it should work on non-windows machines. If it's not feel free to contact me.
Make sure to restore all packages with Nuget before build.
## Connecting to db
`DAL.fs` stands for data-access layer. Make sure to provide your Mongo DB settings before building the project. You may use [atlas](http://www.nationalparkcity.london/station_walks) to obtain your free of charge Mongo DB instance.
## Populating db with data
`SeedStations.fs` contains data that should be stored inside the DB. Make sure to execute `SeedStations.seed` before first run.
## Contributing
Feel free to submit bugs/feature requests or PRs but as this is my pet project I don't promise to visit this with the pace that you might expect from me.
