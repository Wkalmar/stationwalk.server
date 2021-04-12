import { Route } from "../models/route";

declare const window: any;
declare const process: any;

export class RouteToCheckPointsMapper {
    constructor(private route : Route) {}

    public static host: string = process.env.STATIONWALK_GRAPHHOPPER_HOST;

    public static defaultKey: string = process.env.STATIONWALK_GRAPHHOPPER_KEY;
    public static ghRouting: any;

    map = async () => {
        RouteToCheckPointsMapper.ghRouting = new window.GraphHopper.Routing({
            key: RouteToCheckPointsMapper.defaultKey,
            host: RouteToCheckPointsMapper.host,
            vehicle: "foot",
            elevation: false
        })
        this.route.checkpoints.forEach(p =>
            RouteToCheckPointsMapper.ghRouting.addPoint(new window.GraphHopper.Input(p.lattitude, p.longitude)));
        var json = await RouteToCheckPointsMapper.ghRouting.doRequest();
        var path = json.paths[0];
        return path.points;
    }
}

