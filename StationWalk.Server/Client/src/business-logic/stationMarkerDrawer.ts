import * as L from "leaflet";
import { Station } from "../models/station";
import { StationsContainer } from "./stationsContainer";
import { ApplicationContext } from "../applicationContext";

export class StationMarkerDrawer {
    draw = () => {
        let markers: L.LatLngExpression[] = [];
        StationsContainer.stations.forEach((station: Station) => {
            const latLngExpression: L.LatLngExpression = [station.location.lattitude, station.location.longitude]
            new L.Marker(latLngExpression, {
                icon: L.icon({
                    iconUrl: `../assets/${station.branch}.png`
                }),
                title: station.name
            }).addTo(ApplicationContext.map);
            markers.push(latLngExpression);
        })
        var bounds = L.latLngBounds(markers);
        ApplicationContext.map.fitBounds(bounds)
    }
}