(() => {
    fetch("./handlebars.hbs")
        .then(x => x.text())
        .then((templateHTML) => loadContacts(templateHTML));
})();

function loadContacts(templateHTML) {
    const template = Handlebars.compile(templateHTML);
    const html = template({ contacts });
    document.getElementById("contacts").innerHTML = html;
}

function showDetails(id) {
    const current = document.getElementById(id);
    (current.style.display === "block")
        ? current.style.display = "none"
        : current.style.display = "block";
}