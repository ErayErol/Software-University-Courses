function sovle(arr) {
    
    let result = [];
    let number = 1;

    for (let i = 0; i < arr.length; i++) {
        let command = arr[i];

        switch (command) {
            case "add":
                result.push(number);
                break;

            case "remove":
                result.pop();
                break;
        }

        number++;
    }

    if (result.length > 0) {
        console.log(result.join('\n'));
    }else{
        console.log('Empty');
    }
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