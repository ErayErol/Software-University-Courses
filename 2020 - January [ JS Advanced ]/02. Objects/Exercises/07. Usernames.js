function usernames(input) {
    let sort = input.sort(function(a, b) {
        return a.length - b.length || // sort by length, if equal then
               a.localeCompare(b);    // sort by alphabetical order
      });

    let names = new Set(sort);
    
    for (const name of names) {
        console.log(name);
    }
}

usernames(['Ashton',
    'Kutcher',
    'Ariel',
    'Lilly',
    'Keyden',
    'Aizen',
    'Billy',
    'Braston']
);

usernames(['Denise',
    'Ignatius',
    'Iris',
    'Isacc',
    'Indie',
    'Dean',
    'Donatello',
    'Enfuego',
    'Benjamin',
    'Biser',
    'Bounty',
    'Renard',
    'Rot']
);