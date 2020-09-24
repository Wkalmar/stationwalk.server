import { Station } from "./models/station";
import { StationsContainer } from "./business-logic/stationsContainer";
import { ControllersEngine } from "./controllersEngine";
import { ApplicationContext } from "./applicationContext";
import { WelcomeControl } from "./controllers/home/welcomeControl";
import { StationMarkerDrawer } from "./business-logic/stationMarkerDrawer";

declare const window: any;

(async function() {
    const mapboxAccesToken = '<your key here>>';
    const mapUrl = `https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token={accessToken}`;
    const mapCopyright = 'Map data &copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors, <a href="http://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="http://mapbox.com">Mapbox</a>';
    const L = window.L;

    const mymap = L.map('mapid', {
        minZoom: 11,
        maxZoom: 18,
        zoomControl: false
    });
    L.tileLayer(mapUrl, {
        attribution: mapCopyright,
        id: 'mapbox/streets-v11',
        tileSize: 512,
        zoomOffset: -1,
        accessToken: mapboxAccesToken
    }).addTo(mymap);
    L.control.zoom({
        position: 'bottomright'
    }).addTo(mymap);
    const routingLayer = L.geoJSON().addTo(mymap);

    ApplicationContext.map = mymap;
    ApplicationContext.routingLayer = routingLayer;

    const stationsRequestResolver = (stations: Station[]) => {
        StationsContainer.stations = stations;
        new StationMarkerDrawer().draw();
    }

    var response = await fetch('http://localhost:5000/stations')
    try {
        if (response.ok) {
            stationsRequestResolver(await response.json());
        } else {
            throw new Error();
        }
    }
    catch(error) {
        console.error(error)
    };

    const hideWelcomeScreen = window.sessionStorage.getItem(WelcomeControl.hideWelcomeScreensetting);
    if (hideWelcomeScreen) {
        ApplicationContext.alwaysHideWelcomeScreen = hideWelcomeScreen === 'true';
    }

    ControllersEngine.go('home');

    document.getElementsByTagName('nav')[0]
    .addEventListener('click', (e : MouseEvent) => {
        const eventTarget = e.target as HTMLElement;
        ControllersEngine.go(eventTarget.dataset.path || 'home');
    });
})();