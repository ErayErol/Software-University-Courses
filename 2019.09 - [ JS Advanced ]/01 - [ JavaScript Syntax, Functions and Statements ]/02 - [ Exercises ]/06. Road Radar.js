function solve(args) {
    function checkLimit(area) {
        switch (area) {
            case 'motorway': return 130;
            case 'interstate': return 90;
            case 'city': return 50;
            case 'residential': return 20;
        }
    }

    let speed = Number(args[0]);
    let area = args[1];

    let speedLimit = checkLimit(area);
    let overLimit = speed - speedLimit;

    if (overLimit > 0) {
        if (overLimit <= 20) {
            console.log('speeding');
        } else if (overLimit <= 40) {
            console.log('excessive speeding');
        } else {
            console.log('reckless driving');
        }
    }
}

solve([40, 'city']);

solve([21, 'residential']);

solve([120, 'interstate']);

solve([200, 'motorway']);