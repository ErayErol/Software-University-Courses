function solve(steps, footprintLength, speedInKmForHour) {

    let distanceInMeters = steps * footprintLength;

    let speedForMetersInSecond = speedInKmForHour / 3.6;

    let timeSeconds = Math.round(distanceInMeters / speedForMetersInSecond);

    let rest = Math.floor(distanceInMeters / 500);
    timeSeconds += rest * 60;

    let seconds = timeSeconds % 60;
    let minutes = (timeSeconds - seconds) / 60;
    let hour = Math.floor((timeSeconds - seconds) / 3600);

    formatTheOutput(hour, minutes, seconds);
    
    function formatTheOutput(hour, minutes, seconds) {
        if (hour < 10) {
            hour = '0' + hour;
        }
        if (minutes < 10) {
            minutes = '0' + minutes;
        }
        if (seconds < 10) {
            seconds = '0' + seconds;
        }

        console.log(`${hour}:${minutes}:${seconds}`);
    }
}

solve(4000, 0.60, 5);