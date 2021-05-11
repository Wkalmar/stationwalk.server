import { Debounce } from '../../utils/debounce';
import { Station } from '../../models/station';
import { RouteDrawer } from "../../business-logic/routeDrawer";

declare const process: any;

export class StartStationControl {
    private startStationSelectorId: string = "station-start-select";
    private startStationInputId: string = "station-start-input";
    private startStationAutoCompleteContainerId: string = "station-start-autocomplete-container";

    public template: string =
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
        `
    public addEventListeners = () => {
        const startStationInput = document.getElementById(this.startStationInputId);
        if (!startStationInput)
            throw new Error("Invalid markup. Missing start station input");
        startStationInput.addEventListener('keyup', Debounce.do(this.searchStation, 500, this));
    }

    public removeEventListeners = () => {
        const startStationInput = document.getElementById(this.startStationInputId);
        if (!startStationInput)
            throw new Error("Invalid markup. Missing start station input");
        startStationInput.removeEventListener('keyup', Debounce.do(this.searchStation, 500, this));
    }

    public removeTemplate = () => {
        const templateContainer = document.getElementById(this.startStationSelectorId);
        if (templateContainer != null) {
            const container = templateContainer as HTMLElement;
            container.remove();
        }
    }

    private searchStation = async (e: KeyboardEvent) => {
        const target = e.target as HTMLTextAreaElement;
        if (!target)
            throw new Error("Invalid markup. Missing start station input");
        const response = await fetch(`${process.env.STATIONWALK_BACKEND_API}/station/${target.value}`)
        try {
            if (response.ok) {
                return this.displayStartStationAutoComplete(await response.json());
            } else {
                throw new Error();
            }
        }
        catch(error) {
            console.error(error)
        }
    }

    private displayStartStationAutoComplete = (stations: Station[]) => {
        const autoCompleteContainer = document.getElementById(this.startStationAutoCompleteContainerId);
        if (!autoCompleteContainer) {
            throw new Error("Invalid markup. Missing start station autocomplete container");
        }

        autoCompleteContainer.innerHTML = '';

        const ul = document.createElement("ul");
        stations.map(s => {
            const li = document.createElement("li");
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

    private setStartStation = (e: MouseEvent) => {
        const emitter = e.target as HTMLElement;
        if (emitter == null) {
            throw new Error("Invalid markup. Missing start station input");
        }
        const lat = Number(emitter.getAttribute("data-lat"));
        const lng = Number(emitter.getAttribute("data-lng"));
        const routeDrawer = RouteDrawer.drawer;
        routeDrawer.addPoint(lat, lng);

        const autoCompleteContainer = document.getElementById(this.startStationAutoCompleteContainerId);
        if (!autoCompleteContainer) {
            throw new Error("Invalid markup. Missing start station autocomplete container");
        }

        autoCompleteContainer.innerHTML = '';

        const modal = document.getElementById(this.startStationSelectorId);
        if (!modal) {
            throw new Error("Invalid markup. Missing start station modal");
        }
        modal.style.display = 'none';
    }
}