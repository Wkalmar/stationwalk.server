export class Debounce {
    static do = (f: any, ms: number, scope: any, ...args:any) => {

        let isCooldown = false;

        return function () {
            if (isCooldown)
                return;
            f.apply(scope, args);
            isCooldown = true;
            setTimeout(() => isCooldown = false, ms);
        };

    }
}
