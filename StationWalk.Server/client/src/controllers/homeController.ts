import { IController } from "./icontroller";
import { Route } from "../models/route";
import { RouteToCheckPointsMapper } from "../business-logic/routeToCheckpointsMapper";
import { ApplicationContext } from '../applicationContext';

    export class HomeController implements IController {
        constructor() {}

        path = "home";

        private checkPointsCollection: L.Polyline[] = [];

        routesRequestResolver = (routesResponse: Route[]) => {
            routesResponse.map((route: Route) => {
                const mapper = new RouteToCheckPointsMapper(route);
                let checkpoints = mapper.map();
                checkpoints.addTo(ApplicationContext.map);
                this.checkPointsCollection.push(checkpoints);
            })
        }

        go(): void {
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

        clear(): void {
            this.checkPointsCollection.map(p => p.removeFrom(ApplicationContext.map));
            this.checkPointsCollection = [];
        }
    }
