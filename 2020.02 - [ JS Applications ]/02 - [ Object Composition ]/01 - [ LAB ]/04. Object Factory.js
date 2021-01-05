function solve(input) {
    return JSON.parse(input)
        .reduce((acc, curr) =>
            Object.assign(acc, curr), {});
}

console.log(solve(`[{"canMove": true},{"canMove":true, "doors": 4},{"capacity": 5}]`));
console.log(solve(`[{"canFly": true},{"canMove":true, "doors": 4},{"capacity": 255},{"canFly":true, "canLand": true}]`));