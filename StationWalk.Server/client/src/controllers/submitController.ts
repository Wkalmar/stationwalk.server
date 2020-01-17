import { Route } from './../models/route';
import { IController } from "./icontroller";
import { RouteDrawer } from "../business-logic/routeDrawer";
import { ControllersEngine } from '../controllersEngine';
import { ApplicationContext } from '../applicationContext';
import { Station } from '../models/station';
import { Debounce } from '../utils/debounce';

export class SubmitController implements IController {
    constructor() {}

    path = "submit";

    private startStationSelectorId: string = "station-start-select";
    private startStationInputId: string = "station-start-input";
    private startStationAutoCompleteContainerId: string = "station-start-autocomplete-container";

    private submitModalId: string = "submit-modal";
    private submitModalFormId : string = "submit-modal-form";
    private routeNameInputId : string = "route-name";
    private submitButtonId : string = "route-submit-button";
    private submitSuccessNotificationContainerId : string = "submit-modal-success";
    private gotoHomeButtonId : string = "route-submit-goto-home";

    private routeToSubmit : Route;

    private controllerTemplate : string =
    `
    <div id="${this.startStationSelectorId}" class="modal" style="display: block;">
        <div class="modal-content">
            <div>
                <label for="${this.startStationInputId}">Start station</label>
                <input type="text" id="${this.startStationInputId}" placeholder="Enter start station...">
                <div id="${this.startStationAutoCompleteContainerId}"></div>
            </div>
        </div>
    </div>
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
            <button id="${this.gotoHomeButtonId}">Go to home page</button>
        </div>
    </div>`

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

    private addStationStartFormEventListeners = () => {
        const startStationInput = document.getElementById(this.startStationInputId);
        if (!startStationInput)
            throw new Error("Invalid markup. Missing start station input");
        startStationInput.addEventListener('keyup', Debounce.do(this.searchStation, 500, this));
    }

    private setStartStation = (e: MouseEvent) => {
        const emitter = e.target as HTMLElement;
        if (emitter == null) {
            throw new Error("Invalid markup. Missing start station input");
        }
        let lat = Number(emitter.getAttribute("data-lat"));
        let lng = Number(emitter.getAttribute("data-lng"));
        const routeDrawer = RouteDrawer.drawer;
        routeDrawer.addPoint(lat, lng);

        let autoCompleteContainer = document.getElementById(this.startStationAutoCompleteContainerId);
        if (!autoCompleteContainer) {
            throw new Error("Invalid markup. Missing start station autocomplete container");
        }

        autoCompleteContainer.innerHTML = '';

        let modal = document.getElementById(this.startStationSelectorId);
        if (!modal) {
            throw new Error("Invalid markup. Missing start station modal");
        }
        modal.style.display = 'none';
    }

    private displayStartStationAutoComplete = (stations: Station[]) => {
        let autoCompleteContainer = document.getElementById(this.startStationAutoCompleteContainerId);
        if (!autoCompleteContainer) {
            throw new Error("Invalid markup. Missing start station autocomplete container");
        }

        autoCompleteContainer.innerHTML = '';

        let ul = document.createElement("ul");
        stations.map(s => {
            let li = document.createElement("li");
            li.textContent = s.name;

            const latAttribute = document.createAttribute("data-lat");
            latAttribute.value = s.location.lattitude.toString();
            li.attributes.setNamedItem(latAttribute);

            const lngAttribute = document.createAttribute("data-lng");
            lngAttribute.value = s.location.longitude.toString();
            li.attributes.setNamedItem(lngAttribute);

            li.addEventListener('click', this.setStartStation);
            ul.appendChild(li);
        });

        autoCompleteContainer.appendChild(ul);
    }

    private searchStation = (e: KeyboardEvent) => {
        var target = e.target as HTMLTextAreaElement;
        if (!target)
            throw new Error("Invalid markup. Missing start station input");
        fetch(`http://localhost:5000/station/${target.value}`)
            .then((response) => {
                if (response.ok) {
                    return response.json();                        
                } else {
                    throw new Error();
                }
            })
            .then(this.displayStartStationAutoComplete)
            .catch((error) => {
                console.error(error)
            });
    }

    go = () => {
        this.addControllerTemplate();
        this.addMapEventListeners();
        this.addDrawingSubmittedEventListener();
        this.addSubmitFormEventListeners();
        this.addStationStartFormEventListeners();
    }
    private addControllerTemplate = () => {
        let controllerTemplateContainer = document.getElementById('controller-template-container');
        if (controllerTemplateContainer == null) {
            throw new Error('Invalid html. Page should contain element with id controller-template-container');
        }
        let container = controllerTemplateContainer as HTMLElement;
        container.insertAdjacentHTML('beforebegin', this.controllerTemplate);
    }

    private removeControllerTemplate = () => {
        let controllerTemplateContainer = document.getElementById(this.submitModalId);
        if (controllerTemplateContainer != null) {
            var container = controllerTemplateContainer as HTMLElement;
            container.remove();
        }
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

    private submit = () : void => {
        let nameInput = document.getElementById(this.routeNameInputId) as HTMLInputElement;
        let inputText = nameInput && nameInput.value;
        if (!inputText) {
            alert('enter route name');
            return;
        }
        this.routeToSubmit.name = inputText as string;
        fetch('http://localhost:5000/route', {
            method: 'POST',
            headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
            },
            body: JSON.stringify(this.routeToSubmit)
        })
        .then(() => {
            this.showSuccessNotification();
        });
    }
}
