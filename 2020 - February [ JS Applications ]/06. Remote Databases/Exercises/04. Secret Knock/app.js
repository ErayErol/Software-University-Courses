let query = "Knock Knock.";

const button = document.getElementById("knockBtn");
button.addEventListener("click", submit);

async function submit() {
    button.style.display = 'none';
    const headers = {
        method: "GET",
        headers: {
            "Authorization": `Basic ${btoa("guest:guest")}`,
            "Content-Type": "application/json",
        }
    };

    while (query) {
        console.log(query);
        const response = await fetch(`https://baas.kinvey.com/appdata/kid_BJXTsSi-e/knock?query=${query}`, headers);
        const x = await response.json();
        console.log(x.answer);
        query = x.message;
    }
}