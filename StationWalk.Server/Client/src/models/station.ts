import { Location } from './location';

export class Station {
    id: string
    name: string
    location: Location
    branch: Branch
}

export const enum Branch {
    Red = "Red",
    Blue = "Blue",
    Green = "Green"
}