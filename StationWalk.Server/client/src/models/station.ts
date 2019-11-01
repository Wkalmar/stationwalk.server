import { Location } from './location';

export class Station {
    name: string
    location: Location
    branch: Branch
}

export enum Branch {
    Red = "Red",
    Blue = "Blue",
    Green = "Green"
}