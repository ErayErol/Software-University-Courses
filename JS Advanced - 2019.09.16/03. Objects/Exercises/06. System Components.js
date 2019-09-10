function systemComponents(input) {
    let systems = new Map();
    for (const line of input) {
        let tokens = line.split(' | ');
        let system = tokens[0];
        let component = tokens[1];
        let subcomponent = tokens[2];

        if (systems.has(system) == false) {
            systems.set(system, new Map());
        }

        if (systems.get(system).has(component) == false) {
            systems.get(system).set(component, []);
        }

        systems.get(system).get(component).push(subcomponent);
    }

    let orderedByAmountOfComponentsAndAlphabetical = new Map(
        Array
            .from(systems)
            .sort((a, b) => {
                // a[0], b[0] is the key of the map
                return a[0] > b[0];
            })
            .sort((a, b) => {
                // a[1], b[1] is the value of the map
                return b[1].size - a[1].size;
            })
    );

    for (const key of orderedByAmountOfComponentsAndAlphabetical) {
        console.log(key[0]);

        let orderedByAmountOfSubcomponents = new Map(
            Array
                .from(key[1])
                .sort((a, b) => {
                    return b[1].length - a[1].length;
                }));

        for (const components of orderedByAmountOfSubcomponents) {
            console.log(`|||${components[0]}`);

            for (const sub of components[1]) {
                console.log(`||||||${sub}`);
            }
        }
    }
}

systemComponents(['SULS | Main Site | Home Page',
    'SULS | Main Site | Login Page',
    'SULS | Main Site | Register Page',
    'SULS | Judge Site | Login Page',
    'SULS | Judge Site | Submittion Page',
    'Lambda | CoreA | A23',
    'SULS | Digital Site | Login Page',
    'Lambda | CoreB | B24',
    'Lambda | CoreA | A24',
    'Lambda | CoreA | A25',
    'Lambda | CoreC | C4',
    'Indice | Session | Default Storage',
    'Indice | Session | Default Security']
);

// Lambda
// |||CoreA
// ||||||A23
// ||||||A24
// ||||||A25
// |||CoreB
// ||||||B24
// |||CoreC
// ||||||C4
// SULS
// |||Main Site
// ||||||Home Page
// ||||||Login Page
// ||||||Register Page
// |||Judge Site
// ||||||Login Page
// ||||||Submittion Page
// |||Digital Site
// ||||||Login Page
// Indice
// |||Session
// ||||||Default Storage
// ||||||Default Security