function loadRepos() {
	const username = document.getElementById('username').value;
	const repositories = document.getElementById('repos');

	fetch(`https://api.github.com/users/${username}/repos`)
		.then(cleaner())
		.then((response) => response.json())
		.then((data) => displayRepositories(data))
		.catch((error) => displayError(error));

	function displayRepositories(repoItems) {
		repoItems.forEach(repo => {
			const a = document.createElement('a');
			const li = document.createElement('li');

			a.textContent = repo.full_name;
			a.href = repo.html_url;
			li.appendChild(a);
			repositories.appendChild(li);
		});
	}

	function displayError(error) {
		const li = document.createElement('li');
		li.textContent = error;
		repositories.appendChild(li);
	}

	function cleaner() {
		repositories.innerHTML = '';
	}
}