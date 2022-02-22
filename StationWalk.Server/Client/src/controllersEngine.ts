import { IController } from "./icontroller";
import { HomeController } from "./controllers/home/homeController";
import { SubmitController } from "./controllers/submit/submitController";

export class ControllersEngine {
    private static currentController : IController
    private static currentPath : string

    public static go = (path: string) => {
        if (ControllersEngine.currentPath === path) {
            return
        }
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
        if (ControllersEngine.currentController != null) {
            ControllersEngine.currentController.clear();
        }
        ControllersEngine.currentController = newController;
        ControllersEngine.currentPath = path;
        ControllersEngine.currentController.go();
    }
}