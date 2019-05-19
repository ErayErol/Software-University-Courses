function solve(arr) {
    for (let i = 0; i < arr.length; i++) {
        let arrElement = arr[i].split(", ");

        for (let j = 0; j < arrElement.length; j++) {
            let currentInputElement = arrElement[j];
            console.log(currentInputElement);
        }
        return;
    }

}

solve(['1.00, coffee, caffeine, milk, 4', '0.40, tea, milk, 2', '1.00, coffee, decaf, 0']);