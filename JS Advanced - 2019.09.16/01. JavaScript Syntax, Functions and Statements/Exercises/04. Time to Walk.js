function solve(step, lengthOfStep, speed) {
    let distance = step * lengthOfStep / 1000;
    let speedForSecond = speed / 3600;

    let seconds = Math.round(distance / speedForSecond);
    let minutes = Math.floor(step * lengthOfStep / 500);
    let hours = 0;

    while (seconds > 60) {
        seconds -= 60;
        minutes++;
    }

    while (minutes > 60) {
        minutes -= 60;
        hours++;
    }

    seconds = seconds > 10 ? seconds : `0${seconds}`;
    minutes = minutes > 10 ? minutes : `0${minutes}`;
    hours = hours > 10 ? hours : `0${hours}`;
    console.log(`${hours}:${minutes}:${seconds}`);
}

solve(4000, 0.60, 5);

solve(2564, 0.70, 5.5);