export abstract class IController {
    abstract path: string;
    abstract template: string;
    abstract go(): void;
    abstract clear(): void;

    protected addControllerTemplate = () => {
        let controllerTemplateContainer = document.getElementById('controller-template-container');
        if (controllerTemplateContainer == null) {
            throw new Error('Invalid html. Page should contain element with id controller-template-container');
        }
        let container = controllerTemplateContainer as HTMLElement;
        container.insertAdjacentHTML('beforebegin', this.template);
    }

    abstract removeControllerTemplate(): void;
}
