function solve(arr) {
    let speed = Number(arr[0]);
    let area = arr[1];

    let result = '';

    if (area === 'motorway'){
        if (speed <= 130){
            return result;
        }else if (speed > 0){
            if (speed - 20 <= 130){
                return result = 'speeding'
            } else if (speed - 40 <= 130){
                return result = 'excessive speeding'
            }else {
                return result = 'reckless driving';
            }
        }
    }else if (area === 'interstate'){
        if (speed <= 90){
            return result;
        }else if (speed > 0){
            if (speed - 20 <= 90){
                return result = 'speeding'
            } else if (speed - 40 <= 90){
                return result = 'excessive speeding'
            }else {
                return result = 'reckless driving';
            }
        }
    }else if (area === 'city'){
        if (speed <= 50){
            return result;
        }else if (speed > 0){
            if (speed - 20 <= 50){
                return result = 'speeding'
            } else if (speed - 40 <= 50){
                return result = 'excessive speeding'
            }else {
                return result = 'reckless driving';
            }
        }
    }else if (area === 'residential'){
        if (speed <= 20){
            return result;
        }else if (speed > 0){
            if (speed - 20 <= 20){
                return result = 'speeding'
            } else if (speed - 40 <= 20){
                return result = 'excessive speeding'
            }else {
                return result = 'reckless driving';
            }
        }
    }

    area.arguments
}