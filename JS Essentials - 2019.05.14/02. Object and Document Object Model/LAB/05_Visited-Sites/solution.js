function solve() {
    let element = document.getElementById("exercise");

    let softuniClick = 1;
    let googleClick = 2;
    let youtubeCLick = 3;
    let wikipediaCLick = 4;
    let gmailCLick = 5;
    let stackoverflowCLick = 6;

    document.getElementsByTagName('a')[0].addEventListener('click', function() {
        let times = element.getElementsByTagName("span")[0].textContent = `Visited: ${++softuniClick} times`;
    });

    document.getElementsByTagName('a')[1].addEventListener('click', function() {
        let times = element.getElementsByTagName("span")[1].textContent = `Visited: ${++googleClick} times`;
    });

    document.getElementsByTagName('a')[2].addEventListener('click', function() {
        let times = element.getElementsByTagName("span")[2].textContent = `Visited: ${++youtubeCLick} times`;
    });

    document.getElementsByTagName('a')[3].addEventListener('click', function() {
        let times = element.getElementsByTagName("span")[3].textContent = `Visited: ${++wikipediaCLick} times`;
    });

    document.getElementsByTagName('a')[4].addEventListener('click', function() {
        let times = element.getElementsByTagName("span")[4].textContent = `Visited: ${++gmailCLick} times`;
    });

    document.getElementsByTagName('a')[5].addEventListener('click', function() {
        let times = element.getElementsByTagName("span")[5].textContent = `Visited: ${++stackoverflowCLick} times`;
    });
}