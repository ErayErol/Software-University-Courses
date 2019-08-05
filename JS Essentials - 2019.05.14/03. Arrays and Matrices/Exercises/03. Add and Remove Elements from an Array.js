function sovle(arr) {
    let number = 1;

    let result = [];

    for (let i = 0; i < arr.length; i++) {
        const command = arr[i];

        switch (command) {
            case "add":
                result.push(number);
                break;

            case "add":
                arr.pop();
                break;
        }

        number++;
    }

    console.log(result.join('\n'));
}

sovle(['add',
    'add',
    'add',
    'add']
);

sovle(['add',
    'add',
    'remove',
    'add',
    'add']
);

sovle(['remove',
    'remove',
    'remove']
);