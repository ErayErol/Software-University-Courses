(async () => {
    Handlebars.registerPartial("cat", await fetch("./cat-handlebars.hbs").then((r) => r.text()));
    fetch("./cats-handlebars.hbs")
        .then(x => x.text())
        .then((templateHTML) => loadContacts(templateHTML));
})();

function loadContacts(templateHTML) {
    const template = Handlebars.compile(templateHTML);
    const html = template({ cats });
    document.getElementById("allCats").innerHTML = html;
}

function showDetails(id) {
    const current = document.getElementById(id);
    if (current.style.display === "block") {
        current.style.display = "none";
        event.currentTarget.textContent = "Show status code";
    } else {
        current.style.display = "block";
        event.currentTarget.textContent = "Hide status code";
    }
}