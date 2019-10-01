function toggle() {
    let button = document.getElementsByClassName("button")[0];
    let text = document.getElementById("extra");
    
    if (button.textContent === "More") {
        text.style.display = "block";
        button.textContent = "Less";
    } else {
        text.style.display = "none";
        button.textContent = "More";
    }
}