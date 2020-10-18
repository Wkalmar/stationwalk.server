import { Route } from "../models/route";

declare const window: any;

export class RouteToCheckPointsMapper {
    constructor(private route : Route) {}

    public static host: string = "https://graphhopper.com/api/1";

    public static defaultKey: string = "d71f3005-4353-4685-8b67-308ae19d6ecb";
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

