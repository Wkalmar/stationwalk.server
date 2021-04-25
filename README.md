## Kyiv station walk
This project is Kyiv's clone of [London station walk](http://www.nationalparkcity.london/station_walks).
The goal for end users is to highlight some of the most iconic Kyiv's hiking routes which start and end with a subway station. The goal for me is to try architectural and coding approaches of interest. And for you if you want to contribute.

## Architectural overview
As I've already mentioned I wanted to experiment in this project a bit, so I've tried a few things such as serverless or F# as a server side language. Here's how the project structured.

![Architectural diagram](https://raw.githubusercontent.com/Wkalmar/stationwalk.server/master/Architecture.png)
Let's break it down what happens here.

The core of the project is a web server written using [Giraffe framework](https://github.com/giraffe-fsharp/Giraffe). First and foremost I wanted to try out F# in a real-world scenario as I imagine it as very promising technology due to both it's functional-first nature and support of .Net core framework.

The web server communicates with [Elasticsearch](https://www.elastic.co/what-is/elasticsearch) db. After some experiments with storage I've decided to use Elasticsearch in order to leverage it's advanced searching capabilities such as fuzzy search.
Web server provides REST API for the front-end. My decision was to build front-end without any frameworks since they're quite heavyweight for such a smallish application. And each piece of Javascript code is more bytes to download wich means less responsive application. The only temptation I couldn't resist is to use Typescript because it allows me to gain some compile-time safety.

Authorization is performed via AWS-Lambda that is defined [here](https://github.com/Wkalmar/stationwalk.auth). I've covered the reasoning behind it [in my blog](https://wkalmar.github.io/post/building-auth-endpoint-with-go-and-aws-lambda/).

Regarding admin portal I haven't gotten to it yet, but it can be build as a separate micro-frontend as it doesn't need to possess all those architectural constraints that main UI part has.

Another thing I've decided to try is SightSafari API which would recommend some nice places along the suggested route.

## Setting up the project
### Environment
In order to be able to start the project you'll need:
- .Net 5 for the backend
- Elasticsearch for the storage. Alternatively you can run one from docker-compose supplied in the project.
- Node js in order to be able to run `npm i` in order to restore front-end packages
### Configuration
Configuration is done via .env file. This file exhibits environment properties both for back and front end. To run project successfully you need mapbox and graphhopper accounts and supply obtained api keys into respective variables.
### Running the project
Both front-end and back-end are running in a single Visual Studio solution so if you using Visual Studio you should just run it and you're golden.
### Seeding stations
`SeedStations` module contains method `seed` which inserts all Kyiv's subway stations into Elastic db so if you're running the project for the first time you should call this method in your `main`.

## Sort of a roadmap
There is plenty of stuff to do. The 3 main points I'll highlight are:
- Improve interaction with Elasticsearch by switching to the low-level client since Nest library is a complete mess IMO.
- The UI is rather sketchy. The project needs real UI.
- Some sort of admin portal.
- Put Redis cache in front of SightSafari API.
- Add localization.

## Contributing
Feel free to submit bugs/feature requests or PRs I'll do my best to answer.
