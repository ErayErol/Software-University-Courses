document.addEventListener("DOMContentLoaded", main());

function main() {
    const link = document.getElementById('gLink');
    const cb = document.getElementById('cb');
    click(link, cb);
}

function click(link, cb) {
    link.addEventListener("click", function (e) {
        if (!cb.checked) {
            e.preventDefault();
        }
    });
}
