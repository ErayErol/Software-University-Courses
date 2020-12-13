function notify(message) {
    let notification = document.getElementById('notification');
    notification.textContent = message;
    notification.style.display = 'block';

    setTimeout(function () {
        notification.style.display = 'none';
    }, 2000);
}