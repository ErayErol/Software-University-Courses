function arenaTier(input) {
    let gladiators = new Map();
    for (const line of input) {
        let tokens = line.split(' -> ');
        let command = tokens[0].split(' vs ');
        if (command.length === 1) {
            let name = tokens[0];
            if (name === 'Ave Cesar') {
                break;
            }
            let technique = tokens[1];
            let skills = Number(tokens[2]);

            if (gladiators.has(name) == false) {
                gladiators.set(name, new Map());
            }

            if (gladiators.get(name).has(technique) == false) {
                gladiators.get(name).set(technique, 0);
            }

            if (skills > gladiators.get(name).get(technique)) {
                gladiators.get(name).set(technique, skills);
            }
        }
        else if (command.length === 2) {
            let gladiator1 = command[0];
            let gladiator2 = command[1];
            let isDuel = false;

            for (let [technique1, skills1] of gladiators.get(gladiator1)) {
                
                for (let [technique2, skills2] of gladiators.get(gladiator2)) {
                    if (technique1 === technique2) {
                        if (skills1 > skills2) {
                            gladiators.delete(gladiator2);
                        } else {
                            gladiators.delete(gladiator1);
                        }
                        isDuel = true;
                        break;
                    }
                }

                if (isDuel) {
                    break;
                }
            }
        }
    }

    b;
}

// arenaTier(["Pesho -> BattleCry -> 400",
//     "Gosho -> PowerPunch -> 300",
//     "Stamat -> Duck -> 200",
//     "Stamat -> Tiger -> 250",
//     "Ave Cesar"
// ]);

arenaTier(["Pesho -> Duck -> 400",
    "Julius -> Shield -> 150",
    "Gladius -> Heal -> 200",
    "Gladius -> Support -> 250",
    "Gladius -> Shield -> 250",
    "Pesho vs Gladius",
    "Gladius vs Julius",
    "Gladius vs Gosho",
    "Ave Cesar"
]);