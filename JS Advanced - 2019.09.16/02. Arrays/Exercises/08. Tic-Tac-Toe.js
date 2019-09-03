function solve(moves) {
    let dashboard = [
        [false, false, false],
        [false, false, false],
        [false, false, false]
    ];

    let firstPlayer = 'X';
    let secondPlayer = 'O';

    for (let i = 0; i < moves.length; i++) {
        let move = moves[i];
        let row = move[0];
        let col = move[2];

        if (dashboard[row][col] === firstPlayer ||
            dashboard[row][col] === secondPlayer &&
            i < moves.length - 1) {

            console.log('This place is already taken. Please choose another!');
            moves.splice(i, 1);

            move = moves[i];
            row = move[0];
            col = move[2];
        }


        if (i % 2 === 0) {
            if (dashboard[row][col] === false) {
                dashboard[row][col] = firstPlayer;
            }
        } else {
            if (dashboard[row][col] === false) {
                dashboard[row][col] = secondPlayer;
            }
        }

        if (i > 3) {
            if (isWin(firstPlayer)) {
                console.log(`Player ${firstPlayer} wins!`);
                print(dashboard);
                return;
            } else if (isWin(secondPlayer)) {
                console.log(`Player ${secondPlayer} wins!`);
                print(dashboard);
                return;
            }
        }
    }

    console.log('The game ended! Nobody wins :(');
    print(dashboard);

    function isWin(player) {
        if (dashboard[0][0] === player &&
            dashboard[0][1] === player &&
            dashboard[0][2] === player ||
            dashboard[0][0] === player &&
            dashboard[1][1] === player &&
            dashboard[2][2] === player ||
            dashboard[0][0] === player &&
            dashboard[1][0] === player &&
            dashboard[2][0] === player ||
            dashboard[0][1] === player &&
            dashboard[1][1] === player &&
            dashboard[2][1] === player ||
            dashboard[0][2] === player &&
            dashboard[1][2] === player &&
            dashboard[2][2] === player ||
            dashboard[0][2] === player &&
            dashboard[1][1] === player &&
            dashboard[2][0] === player ||
            dashboard[1][0] === player &&
            dashboard[1][1] === player &&
            dashboard[1][2] === player ||
            dashboard[2][0] === player &&
            dashboard[2][1] === player &&
            dashboard[2][2] === player) {

            return true;
        }

        return false;
    }

    function print(dashboard) {
        dashboard.forEach(row => console.log(row.join('\t')));
    }
}

solve(["0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 1",
    "1 2",
    "2 2",
    "2 1",
    "0 0"]
);

solve(["0 0",
    "0 0",
    "1 1",
    "0 1",
    "1 2",
    "0 2",
    "2 2",
    "1 2",
    "2 2",
    "2 1"]
);

solve(["0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 2",
    "1 1",
    "2 1",
    "2 2",
    "0 0"]
);