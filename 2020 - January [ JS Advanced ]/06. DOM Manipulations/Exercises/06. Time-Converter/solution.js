function attachEventsListeners() {
    let days = document.getElementById('days');
    let hours = document.getElementById('hours');
    let minutes = document.getElementById('minutes');
    let seconds = document.getElementById('seconds');

    document.body.addEventListener('click', (e) => {
        let id = e.target.id;
        
        if (id === 'daysBtn') {
            hours.value = days.value * 24;
            minutes.value = hours.value * 60;
            seconds.value = minutes.value * 60;
        } else if (id === 'hoursBtn') {
            days.value = hours.value / 24;
            minutes.value = hours.value * 60;
            seconds.value = minutes.value * 60;
        } else if (id === 'minutesBtn') {
            seconds.value = minutes.value * 60;
            hours.value = minutes.value / 60;
            days.value = hours.value / 24;
        } else if (id === 'secondsBtn') {
            minutes.value = seconds.value / 60;
            hours.value = minutes.value / 60;
            days.value = hours.value / 24;
        }
    });
}