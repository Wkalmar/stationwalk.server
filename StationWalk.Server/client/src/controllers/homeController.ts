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

    private checkPointsCollection: L.Polyline[] = [];

    routesRequestResolver = (routesResponse: Route[]) => {
        routesResponse.map((route: Route) => {
            const mapper = new RouteToCheckPointsMapper(route);
            let checkpoints = mapper.map();
            checkpoints.addTo(ApplicationContext.map);
            this.checkPointsCollection.push(checkpoints);
        })
    }

    go = () => {
        this.addControllerTemplate();
        this.welcomeControl.addEventListeners();
        fetch('http://localhost:5000/routes')
        .then((response) => {
            if (response.ok) {
                ApplicationContext.map.setView([50.425, 30.521], 12);
                return response.json();
            } else {
                throw new Error();
            }
        })
        .then(this.routesRequestResolver)
        .catch((error) => {
            console.error(error)
        });
    }

    clear = () => {
        this.checkPointsCollection.map(p => p.removeFrom(ApplicationContext.map));
        this.checkPointsCollection = [];
        this.removeControllerTemplate();
    }

    removeControllerTemplate = () => {
        this.welcomeControl.removeTemplate();
    }
}
