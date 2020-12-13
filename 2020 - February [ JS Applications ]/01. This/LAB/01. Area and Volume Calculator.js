function solve(area, vol, input) {

    return JSON.parse(input)
        .map(point => {
            let sum = Object.values(point).reduce((a, b) => Number(a) + Number(b), 0);

            if (isNaN(sum)) {
                throw new Error('Point must be number!');
            }

            return {
                area: Math.abs(area.call(point)),
                volume: Math.abs(vol.call(point))
            };
        });
}

function vol() {
    return this.x * this.y * this.z;
}

function area() {
    return this.x * this.y;
}

try {
    console.log(solve(area, vol, `[
        {"x":"1","y":"2","z":"10"},
        {"x":"7","y":"7","z":"10"},
        {"x":"5","y":"2","z":"10"}
        ]`
    ));
} catch (error) {
    console.log(error);
}