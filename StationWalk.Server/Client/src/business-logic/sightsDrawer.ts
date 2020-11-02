import { Sight } from '../models/sight';
import "../controllers/sights/sights.css"

export class SightsDrawer {
    public draw = (sights: Sight[]) => {
        let sightCards = sights.map(s =>
            `<div>
                <a href="${s.links[0]}">${s.name || s.localizedName}</a>
                <img src="${s.imageLink}"/>
            </div>`);
        let res = `<div class="sights-container">`;
        res += sightCards.reduce((acc, s) => acc += s, res);
        res += "</div>";
        return res;
    }

    static drawer = new SightsDrawer();
}