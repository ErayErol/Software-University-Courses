const elements = {
    $showInfoBtn: () => document.getElementsByTagName("button")[0],
    $info: () => document.getElementsByClassName("info")[0],
    $contact: () => document.getElementById("contact"),
    $contactTemplate: () => document.getElementById("contact-template"),
};

let src = elements.$contactTemplate().innerHTML;
let template = Handlebars.compile(src);

const name = "Eray Erol";
const phone = "+359 886 91 14 92";
const email = "errayerrol@gmail.com";
const context = { name, phone, email };
let html = template(context);

showPage();
infoButtonClick();

function infoButtonClick() {
    elements.$showInfoBtn().addEventListener("click", showAndHide);
}

function showPage() {
    elements.$contact().innerHTML = html;
}

function showAndHide() {
    elements.$info().style.display === "none"
        ? elements.$info().style.display = "block"
        : elements.$info().style.display = "none";
}