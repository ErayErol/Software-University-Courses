function personalBMI(name, age, weight, height) {
    
    function calculateBMI(weight, height) {
        return Math.round(weight / Math.pow(height / 100, 2));
    }

    let person = {
        name: name,
        personalInfo: {
            age: age,
            weight: weight,
            height: height,
        },

        BMI: calculateBMI(weight, height),
        status:''
    };

    if (person.BMI < 18.5) {
        person.status = 'underweight';
    } else if (person.BMI < 25) {
        person.status = 'normal';
    } else if (person.BMI < 30) {
        person.status = 'overweight';
    } else if (person.BMI >= 30) {
        person.status = 'obese';
        person.recommendation = 'admission required';
    }

    return person;
}

console.log(personalBMI('Peter', 29, 75, 182));

console.log(personalBMI('Honey Boo Boo', 9, 57, 137));