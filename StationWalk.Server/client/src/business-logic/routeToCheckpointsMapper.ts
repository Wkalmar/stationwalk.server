import * as L from "leaflet";
import { Route } from "../models/route";

export class RouteToCheckPointsMapper {
    constructor(private route : Route) {}

    private mapCheckpoints = (transformedCheckpoints: L.LatLngExpression[]) => {
        this.route.checkpoints.map(checkpoint => {
            transformedCheckpoints.push([
                checkpoint.lattitude,
                checkpoint.longitude
            ]);
        });
    }

    map = () : L.Polyline => {
        let transformedCheckpoints : L.LatLngExpression[] = []
        this.mapCheckpoints(transformedCheckpoints);
        return L.polyline(transformedCheckpoints);
    }
}

