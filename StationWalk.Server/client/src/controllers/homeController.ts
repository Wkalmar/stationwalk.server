import { IController } from "./icontroller";
import { Route } from "../models/route";
import { RouteToCheckPointsMapper } from "../business-logic/routeToCheckpointsMapper";
import { ApplicationContext } from '../applicationContext';
import { WelcomeControl } from "../controls/welcomeControl";

export class HomeController extends IController {
    constructor() {
        super()
    }

    private welcomeControl: WelcomeControl = new WelcomeControl();

    path = "home";

    template = `${this.welcomeControl.render()}`

    routesRequestResolver = (routesResponse: Route[]) => {
        routesResponse.map(async (route: Route) => {
            const mapper = new RouteToCheckPointsMapper(route);
            let checkpoints = await mapper.map();
            ApplicationContext.routingLayer.addData({
                type: "Feature",
                geometry: checkpoints,
                properties: null
            } as GeoJSON.GeoJsonObject);
        })
    }

    go = async () => {
        this.addControllerTemplate();
        this.welcomeControl.addEventListeners();
        var response = await fetch('http://localhost:5000/routes')
        try {
            if (response.ok) {
                this.routesRequestResolver(await response.json());
            } else {
                throw new Error();
            }
        }
        catch(error) {
            console.error(error)
        };
    }

    clear = () => {
        ApplicationContext.routingLayer.clearLayers();
        this.removeControllerTemplate();
    }

    removeControllerTemplate = () => {
        this.welcomeControl.removeTemplate();
    }
}
