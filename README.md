## Kyiv station walk
This project is Kyiv's clone of [London station walk](http://www.nationalparkcity.london/station_walks).
The goal for end users is to highlight some of the most iconic Kyiv's hiking routes which start and end with a subway station. The goal for me is to try architectural and coding approaches of interest. And for you if you want to contribute.

## Architectural overview
I wanted to experiment in this project a bit, so I've tried a few things such as serverless or F# as a server-side language. Here's how the project is structured.

![Architectural diagram](https://raw.githubusercontent.com/Wkalmar/stationwalk.server/master/Architecture.png)
Let's break it down what happens here.

The core of the project is a web server written using [Giraffe framework](https://github.com/giraffe-fsharp/Giraffe). First and foremost I wanted to try out F# in a real-world scenario as I imagine it as a very promising technology due to both its functional-first nature and support of .Net core framework.

The web server communicates with Mongo DB. There is not much need to strictly follow consistency in data so I've decided to sacrifice consistency in favor of partition tolerance. And among many NoSQL offerings, Mongo DB provided a free tier.

The web server provides REST API for the front-end. My decision was to build the front-end without any frameworks since they're quite heavyweight for such a smallish application. And each piece of Javascript code is more bytes to download which means a less responsive application. The only temptation I couldn't resist is to use Typescript because it allows me to gain some compile-time safety.

Authorization is performed via AWS-Lambda that is defined [here](https://github.com/Wkalmar/stationwalk.auth). I've covered the reasoning behind it [in my blog](https://wkalmar.github.io/post/building-auth-endpoint-with-go-and-aws-lambda/).

Regarding the admin portal, I haven't gotten to it yet, but it can be built as a separate frontend as it doesn't need to possess all those architectural constraints that the main UI part has.

## Setting up the project
### Environment
In order to be able to start locally the project you'll need:
- .Net 5 for the backend
- Mongo DB for the storage.
- Node js in order to be able to run `npm i` in order to restore front-end packages
### Configuration
Configuration is done via .env file. This file exhibits environment properties both for the back and front ends. To run the project successfully you need mapbox and graphhopper accounts and supply obtained API keys into respective variables.
### Running the project
Both front-end and back-end are running in a single Visual Studio solution so `dotnet run` is just enough.

## Deploy
When the code is integrated into master github workflow is executed. This workflow deploys code onto Oracle cloud VM. You can check out deployed application [here](http://140.238.209.37:5000/)

## Roadmap
There is a plenty of stuff to do.
- Improve autocomplete control.
- Add page displaying route info.
- Add the ability to link images uploaded to external service.
- Add admin page to approve submitted routes.
- Add the ability to tag routes.
- Nice design for UI.

## Contributing
Feel free to submit bugs/feature requests or PRs I'll do my best to answer.
