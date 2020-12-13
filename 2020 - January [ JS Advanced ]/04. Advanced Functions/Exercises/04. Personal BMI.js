function personalBMI(name, age, weight, height) {
    
    let person = {
        name: name,
        personalInfo: {
            age: age,
            weight: weight,
            height: height,
        },

        BMI: Math.round(weight / Math.pow(height / 100, 2)),
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