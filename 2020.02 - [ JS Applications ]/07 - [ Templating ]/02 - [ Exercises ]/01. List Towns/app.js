elements = {
    $root: () => document.getElementById("root"),
    $btn: () => document.getElementById("btnLoadTowns"),
    $townsInput: () => document.getElementById("towns"),
};

elements.$btn().addEventListener("click", loadBtn);

function loadBtn() {
    fetch("./templates.hbs")
        .then(x => x.text())
        .then(templateHTML => loadTowns(templateHTML))
        .catch(err => alert(err));

    function loadTowns(templateHTML) {
        const template = Handlebars.compile(templateHTML);
        const towns = elements.$townsInput().value.split(", ").filter(x => x !== "");
        if (towns.length > 0) {
            const html = template({ towns });
            elements.$root().innerHTML = html;
        }
        cleaner();
    }

    function cleaner() {
        elements.$townsInput().value = "";
    }
}