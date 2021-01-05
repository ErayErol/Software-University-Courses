function loadCommits() {
    const usernameInput = document.getElementById('username');
    const repositoryInput = document.getElementById('repo');
    const commitsUL = document.getElementById('commits');

    fetch(`https://api.github.com/repos/${usernameInput.value}/${repositoryInput.value}/commits`)
        .then(cleaner())
        .then(response => responseChecker(response))
        .then(response => renderResponse(response))
        .then(data => renderUserData(data))
        .catch(error => renderErrorMessage(error.message));

    function responseChecker(response) {
        if (response.status > 400) {
            throw new Error(`Error: ${response.status} (${response.statusText})`);
        }
        return response;
    }

    function renderResponse(response) {
        response.json();
    }

    function renderUserData(data) {
        for (const repository of data) {
            const { author, message } = repository.commit;
            const li = document.createElement('li');
            li.textContent = `${author.name}: ${message}`;
            commitsUL.appendChild(li);
        }
    }

    function renderErrorMessage(errorMessage) {
        commitsUL.innerHTML = `<li>${errorMessage}</li>`;
    }

    function cleaner() {
        commitsUL.innerHTML = '';
    }
}