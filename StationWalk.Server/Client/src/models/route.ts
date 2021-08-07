import { Location } from './location';

export class Route {
    id: string
    stationStartId: string
    stationEndId: string
    checkpoints: Location[]
    name: string
    description: string
    approved: boolean
}




