import * as L from "leaflet";
import { StationToMarkerMapper } from "./business-logic/stationToMarkerMapper";
import { Station } from "./models/station";
import { StationsContainer } from "./business-logic/stationsContainer";
import { ControllersEngine } from "./controllersEngine";
import { ApplicationContext } from "./applicationContext";

(function() {
    const mapboxAccesToken = '<your key here>>';
    const mapUrl = `https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token=${mapboxAccesToken}`;
    const mapCopyright = 'Map data &copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors, <a href="http://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="http://mapbox.com">Mapbox</a>';

    const mymap = L.map('mapid');
    L.tileLayer(mapUrl, {
        attribution: mapCopyright,
        maxZoom: 18,
        id: 'mapbox.streets',
        accessToken: mapboxAccesToken
    }).addTo(mymap);
    ApplicationContext.map = mymap;

    const stationsRequestResolver = (stations: Station[]) => {
        StationsContainer.stations = stations;
        stations.map((station: Station) => {
            const mapper = new StationToMarkerMapper(station);
            mapper.map()
                .addTo(mymap);
        })
    }

    fetch('http://localhost:5000/stations')
    .then((response) => {
        if (response.ok) {
            return response.json();
        } else {
            throw new Error();
        }
    })
    .then(stationsRequestResolver)
    .catch((error) => {
        console.error(error)
    });

    ControllersEngine.go('home');

    document.getElementsByTagName('nav')[0]
    .addEventListener('click', (e : MouseEvent) => {
        const eventTarget = e.target as HTMLElement;
        ControllersEngine.go(eventTarget.dataset.path || 'home');
    });
})();