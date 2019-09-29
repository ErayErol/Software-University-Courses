function stopwatch() {
    let hour = 0;
    let minute = 0;
    let seconds = 0;
    let totalSeconds = 0;

    let intervalId = null;
    let isReset = false;

    let time = document.getElementById('time');

    function startTimer() {
        if (isReset) {
            time.textContent = '00:00';
            isReset = false;
        } else {
            ++totalSeconds;
            hour = Math.floor(totalSeconds / 3600);
            minute = Math.floor((totalSeconds - hour * 3600) / 60);
            seconds = totalSeconds - (hour * 3600 + minute * 60);

            if (seconds < 10) {
                seconds = '0' + seconds;
            }

            time.textContent = `0${minute}:${seconds}`;
        }
    }

    let startBtn = document.getElementById('startBtn');
    startBtn.addEventListener('click', () => {
        intervalId = setInterval(startTimer, 1000);

        stopBtn.disabled = false;
        startBtn.disabled = true;
    });

    let stopBtn = document.getElementById('stopBtn');
    stopBtn.addEventListener('click', () => {

        if (intervalId) {
            clearInterval(intervalId);
        }

        hour = 0;
        minute = 0;
        seconds = 0;
        totalSeconds = 0;
        isReset = true;

        stopBtn.disabled = true;
        startBtn.disabled = false;
    });
}