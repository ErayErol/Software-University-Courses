function solve(day, service, time) {
    let dayOfWeek = function (day) {
        return ['Monday', 'Tuesday', 'Wednesday', 'Thursday',
            'Friday', 'Saturday', 'Sunday'].indexOf(day);
    };

    let weekDayService = {
        "Fitness": 5,
        "Sauna": 4,
        "Instructor": 10
    };

    let weekendService = {
        "Fitness": 8,
        "Sauna": 7,
        "Instructor": 15
    };

    if (dayOfWeek(day) <= 4) {
        if (time <= 15) {
            return weekDayService[service];
        }
        else {
            return weekDayService[service] + 2.5;
        }
    }
    else {
        return weekendService[service];
    }
}

console.log(solve('Sunday', 'Fitness', 22.00));