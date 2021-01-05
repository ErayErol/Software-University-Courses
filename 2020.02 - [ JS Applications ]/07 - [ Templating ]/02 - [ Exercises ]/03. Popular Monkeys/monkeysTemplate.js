(async () => {
    Handlebars.registerPartial("monkey", await fetch("./monkey-handlebars.hbs").then((r) => r.text()));
    fetch("./monkeys-handlebars.hbs")
        .then(x => x.text())
        .then(templateHTML => loadMonkey(templateHTML));
})();

function loadMonkey(templateHTML) {
    const template = Handlebars.compile(templateHTML);
    const html = template({ monkeys });
    document.getElementsByClassName("monkeys")[0].innerHTML = html;
}

function showDetails(id) {
    const current = document.getElementById(id);
    (current.style.display === "block")
        ? current.style.display = "none"
        : current.style.display = "block";
}