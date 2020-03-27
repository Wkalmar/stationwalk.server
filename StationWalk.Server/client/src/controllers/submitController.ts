import { Route } from './../models/route';
import { IController } from "./icontroller";
import { RouteDrawer } from "../business-logic/routeDrawer";
import { ControllersEngine } from '../controllersEngine';
import { ApplicationContext } from '../applicationContext';
import { StartStationControl } from '../controls/startStationControl';

export class SubmitController extends IController {
    constructor() {
        super();
    }    

    path = "submit";

    private startStationControl: StartStationControl = new StartStationControl();
    
    private submitModalId: string = "submit-modal";
    private submitModalFormId : string = "submit-modal-form";
    private routeNameInputId : string = "route-name";
    private submitButtonId : string = "route-submit-button";
    private submitSuccessNotificationContainerId : string = "submit-modal-success";
    private gotoHomeButtonId : string = "route-submit-goto-home";

    template =
        `${this.startStationControl.template}
        <div id="${this.submitModalId}" class="modal">
            <div id="${this.submitModalFormId}">
                <div class="modal-content">
                    <div>
                        <label for="${this.routeNameInputId}">Name</label>
                        <input type="text" id="${this.routeNameInputId}" placeholder="Enter route name...">
                    </div>
                    <button id="${this.submitButtonId}">Submit</button>
                </div>
            </div>
            <div id="${this.submitSuccessNotificationContainerId}" class="modal-content" style="display: none;">
                Your route submitted successfully
                <button id="${this.gotoHomeButtonId}" class="button-ok">Go to home page</button>
            </div>
        </div>`

    private routeToSubmit: Route;
  

    private addSubmitFormEventListeners = () => {
        let submitButton = document.getElementById(this.submitButtonId);
        if (submitButton != null)
            submitButton.addEventListener('click', this.submit);

        let goToHomeButton  = document.getElementById(this.gotoHomeButtonId);
        if (goToHomeButton != null)
            goToHomeButton.addEventListener('click', this.goToHome);
    }

    private showSubmitModal = (e: CustomEvent) => {
        let modal = document.getElementById(this.submitModalId);
        if (modal) {
            modal.style.display = 'block';
            this.routeToSubmit = e.detail;
        }
    }

    private goToHome = () => {
        ControllersEngine.go('home');
    }

    private addDrawingSubmittedEventListener = () => {
        document.addEventListener('drawingSubmitted', this.showSubmitModal);
    }

    private addHypotheticalPoint = (e: L.LeafletEvent) => {
        const mouseEvent = e as L.LeafletMouseEvent;
        const routeDrawer = RouteDrawer.drawer;
        routeDrawer.addHypotheticalPoint(mouseEvent.latlng.lat, mouseEvent.latlng.lng);
    }

    private addPoint = (e: L.LeafletEvent) => {
        const mouseEvent = e as L.LeafletMouseEvent;
        const routeDrawer = RouteDrawer.drawer;
        routeDrawer.addPoint(mouseEvent.latlng.lat, mouseEvent.latlng.lng);
    }

    private addMapEventListeners = () => {
        ApplicationContext.map.addEventListener('mousemove', this.addHypotheticalPoint);
        ApplicationContext.map.addEventListener('click', this.addPoint);
    }   

    go = () => {
        this.addControllerTemplate();
        this.addMapEventListeners();
        this.addDrawingSubmittedEventListener();
        this.addSubmitFormEventListeners();
        this.startStationControl.addEventListeners();
    }    

    removeControllerTemplate = () => {
        let controllerTemplateContainer = document.getElementById(this.submitModalId);
        if (controllerTemplateContainer != null) {
            var container = controllerTemplateContainer as HTMLElement;
            container.remove();
        }
        this.startStationControl.removeTemplate();
    }

    private removeSubmitFormEventListeners = () => {
        let submitButton = document.getElementById(this.submitButtonId);
        if (submitButton != null)
            submitButton.removeEventListener('click', this.submit);

        let goToHomeButton  = document.getElementById(this.gotoHomeButtonId);
        if (goToHomeButton != null)
            goToHomeButton.addEventListener('click', this.goToHome);
    }

    private removeMapEventListeners = () => {
        ApplicationContext.map.removeEventListener('mousemove', this.addHypotheticalPoint);
        ApplicationContext.map.removeEventListener('click', this.addPoint);
    }

    private removeDrawingSubmittedeventListener = () => {
        document.removeEventListener('click', this.showSubmitModal);
    }

    clear = () => {
        this.startStationControl.removeEventListeners();
        this.removeMapEventListeners();
        this.removeSubmitFormEventListeners();
        this.removeDrawingSubmittedeventListener();
        this.removeControllerTemplate();
    }

    private showSuccessNotification = () => {
        let submitSuccessNotificationContrainer = document.getElementById(this.submitSuccessNotificationContainerId);
        let submitFormContainer = document.getElementById(this.submitModalFormId);

        if (!submitFormContainer || !submitSuccessNotificationContrainer) {
            throw new Error("Invalid markup. Expected to have form container and successfull notification container");
        }

        (submitFormContainer as HTMLElement).style.display = 'none';
        (submitSuccessNotificationContrainer as HTMLElement).style.display = 'block';
    }

    private submit = async () => {
        let nameInput = document.getElementById(this.routeNameInputId) as HTMLInputElement;
        let inputText = nameInput && nameInput.value;
        if (!inputText) {
            alert('enter route name');
            return;
        }
        this.routeToSubmit.name = inputText as string;
        await fetch('http://localhost:5000/route', {
            method: 'POST',
            headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
            },
            body: JSON.stringify(this.routeToSubmit)
        })
        this.showSuccessNotification();
    }
}
