import { ApplicationContext } from "../applicationContext";

export class WelcomeControl {
    private welcomeScreenId = "welcome-screen";
    private hideButtonId = "welcome-screen-hide";
    private closeButtonId = "welcome-screen-close";

    private template: string =
        `<div class="welcome" id="${this.welcomeScreenId}">
            <div class="modal-content" style="display: block;">
                <p>The goal is to find as many interesting routes which start and end at a subway station as possible. If you know an interesting or scenic route to share do not hesitate!</p>
                <intput id="${this.hideButtonId}" type="checkbox">Do not show this message again</>
            </div>
            <div>
                <button id="${this.closeButtonId}">Got it</button>
            </div>
        </div>`;

    public render = (): string => {
        if (ApplicationContext.displayWelcomeScreen) {
            return this.template
        }
        return "";
    }

    public removeTemplate = () => {
        const templateContainer = document.getElementById(this.welcomeScreenId);
        if (templateContainer != null) {
            var container = templateContainer as HTMLElement;
            container.remove();
        }
    }

    public addEventListeners = () => {
        var closeButton = document.getElementById(this.closeButtonId);
        if (!closeButton) {
            throw new Error("Invalid markup. Close button should be present");
        }
        closeButton.addEventListener('click', this.close);
    }

    private close = () => {
        const templateContainer = document.getElementById(this.welcomeScreenId);
        if (templateContainer == null) {
            throw new Error("Invalid markup. Container should not be empty");
        }
        templateContainer.style.display = 'none';
        ApplicationContext.displayWelcomeScreen = false;
    }
}
