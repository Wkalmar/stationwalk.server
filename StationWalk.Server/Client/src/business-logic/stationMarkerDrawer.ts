import { Station } from "../models/station";
import { StationsContainer } from "./stationsContainer";
import { ApplicationContext } from "../applicationContext";
import { StationToMarkerMapper } from "./stationToMarkerMapper";

declare const window: any;
const L = window.L;

export class StationMarkerDrawer {
    draw = () => {
        const markers: L.LatLngExpression[] = [];
        StationsContainer.stations.forEach((station: Station) => {
            const marker = new StationToMarkerMapper().map(station);
            marker.addTo(ApplicationContext.map);
            markers.push(marker.getLatLng());
        })
        const bounds = L.latLngBounds(markers);
        ApplicationContext.map.fitBounds(bounds)
    }
}