import { Route } from "../models/route";

declare const window: any;

export class RouteToCheckPointsMapper {
    constructor(private route : Route) {}

    public static host: string = "https://graphhopper.com/api/1";

    public static defaultKey: string = "<graphopper key>";
    public static ghRouting = new window.GraphHopper.Routing({
        key: RouteToCheckPointsMapper.defaultKey,
        host: RouteToCheckPointsMapper.host,
        vehicle: "foot",
        elevation: false
    });

    map = async () => {
        this.route.checkpoints.forEach(p =>
            RouteToCheckPointsMapper.ghRouting.addPoint(new window.GraphHopper.Input(p.lattitude, p.longitude)));
        var json = await RouteToCheckPointsMapper.ghRouting.doRequest();
        var path = json.paths[0];
        return path.points;
    }
}

