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

            if (gladiators.has(gladiator1) && gladiators.has(gladiator2)) {
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
    }

    let nameSkills = {};
    for (const gladiator of gladiators) {
        let name = gladiator[0];
        for (const [technique, skills] of gladiator[1]) {

            if (nameSkills.hasOwnProperty(name) == false) {
                nameSkills[name] = 0;
            }

            nameSkills[name] += skills;
        }
    }

    let sortBySkills = [];
    for (let name in nameSkills) {
        sortBySkills.push([name, nameSkills[name]]);
    }

    sortBySkills
        .sort((a, b) => a[0].localeCompare(b[0]))
        .sort((a, b) => b[1] - a[1]);

    for (const gladiator of sortBySkills) {
        let name = gladiator[0];
        let skills = Number(gladiator[1]);
        console.log(`${name}: ${skills} skill`);

        for (const currGladiator of gladiators) {
            if (currGladiator[0] === name) {
                currGladiator[1] = Array.from(currGladiator[1]);
                currGladiator[1]
                    .sort((a, b) => a[0].localeCompare(b[0]))
                    .sort((a, b) => b[1] - a[1]);

                for (const techniqueAndSkills of currGladiator[1]) {
                    console.log(`- ${techniqueAndSkills[0]} <!> ${techniqueAndSkills[1]}`);
                }
            }
        }

    }
}

arenaTier(["Pesho -> BattleCry -> 400",
    "Gosho -> PowerPunch -> 300",
    "Stamat -> Duck -> 200",
    "Stamat -> Tiger -> 250",
    "Ave Cesar"
]);

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