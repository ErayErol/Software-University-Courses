function solve(args) {
    let chop = (num) => {
        return num / 2;
    };

    let dice = (num) => {
        return Math.sqrt(num);
    };

    let spice = (num) => {
        return num + 1;
    };

    let bake = (num) => {
        return num * 3;
    };

    let fillet = (num) => {
        return num * 0.8;
    }

    let num = args.shift();

    while (args.length > 0) {

        let commands = args.shift();

        switch (commands) {
            case 'chop': num = chop(num); break;
            case 'dice': num = dice(num); break;
            case 'spice': num = spice(num); break;
            case 'bake': num = bake(num); break;
            case 'fillet': num = fillet(num); break;
        }

        console.log(num);
    }
}

solve(['32', 'chop', 'chop', 'chop', 'chop', 'chop']);

solve(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);