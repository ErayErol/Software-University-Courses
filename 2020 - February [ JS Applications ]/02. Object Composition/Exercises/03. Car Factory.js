function solve(input) {
    let engineProp = {
        small: { power: Math.abs(input.power - 90), volume: 1800 },
        normal: { power: Math.abs(input.power - 120), volume: 2400 },
        monster: { power: Math.abs(input.power - 200), volume: 3500 },
    };

    let power = {
        small: 90,
        normal: 120,
        monster: 200
    };

    let engine = Math.min(engineProp.small.power, engineProp.normal.power, engineProp.monster.power);
    for (const key in engineProp) {
        const value = engineProp[key];
        if (value.power === engine) {
            value.power = power[key];
            engine = value;
            break;
        }
    }

    return {
        model: input.model,
        engine,
        carriage: {
            type: input.carriage,
            color: input.color,
        },
        wheels: Array(4)
            .fill(input.wheelsize % 2 === 0
                ? input.wheelsize - 1
                : input.wheelsize)
    };
}

console.log(solve({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}));

console.log(solve({
    model: 'Ferrari',
    power: 560,
    color: 'red',
    carriage: 'coupe',
    wheelsize: 21
}));