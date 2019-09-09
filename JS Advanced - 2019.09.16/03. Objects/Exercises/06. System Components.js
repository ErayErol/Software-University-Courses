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

    let systemsSorted = Array.from(systems.keys()).sort((s1, s2) => sortSystems(s1, s2));

    for(let system of systemsSorted) {
        console.log(system);
        let componentsSorted = Array.from(systems.get(system).keys()).sort((c1, c2) => sortComponents(system, c1, c2));

        for(let component of componentsSorted) {
            console.log(`|||${component}`);
            systems.get(system).get(component).forEach(sc => console.log(`||||||${sc}`))
        }
    }

    function sortSystems(s1, s2) {
        if(systems.get(s1).size != systems.get(s2).size) {
            return systems.get(s2).size - systems.get(s1).size;
        } else {
            return s1.toLowerCase().localeCompare(s2.toLowerCase());
        }
    }

    function sortComponents(system, c1, c2) {
        return systems.get(system).get(c2).length - systems.get(system).get(c1).length;
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