import { IController } from "./controllers/icontroller";
import { HomeController } from "./controllers/homeController";
import { SubmitController } from "./controllers/submitController";

export class ControllersEngine {
    private static currentController : IController

    public static go = (path: string) => {
        let newController : IController
        switch (path) {
            case "home":
                newController = new HomeController();
                break;
            case "submit":
                newController = new SubmitController();
                break;
            default:
                newController = new HomeController();
                break;
        }
        if (ControllersEngine.currentController == null ||
                newController.path !== ControllersEngine.currentController.path) {
            if (ControllersEngine.currentController != null) {
                ControllersEngine.currentController.clear();
            }
            ControllersEngine.currentController = newController;
            ControllersEngine.currentController.go();
        }
    }
}