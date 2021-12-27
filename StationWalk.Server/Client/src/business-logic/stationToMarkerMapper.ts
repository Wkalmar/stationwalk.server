
import { Station } from "../models/station";

declare const window: any;
const L = window.L;

export class StationToMarkerMapper {
    map = (station: Station) => {
        const latLngExpression: L.LatLngExpression = [station.location.lattitude, station.location.longitude]
        return new L.Marker(latLngExpression, {
            icon: L.icon({
                iconUrl: `../assets/${station.branch.toLowerCase()}.png`
            }),
            title: station.name.en
        })
    }
}