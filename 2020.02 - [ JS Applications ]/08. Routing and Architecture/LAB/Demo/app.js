const teams = [
    {
        id: 1,
        title: 20,
        manager: "SAF",
        fullName: "Manchester United FC"
    },
    {
        id: 2,
        title: 18,
        manager: "Klopp",
        fullName: "Liverpool FC"
    }
];

const mu = document.getElementById("mu");
const l = document.getElementById("l");
const teamContent = document.getElementById("team-content");

mu.addEventListener("click", () => {
    const teamId = 1;
    addStateAndShowTeam(teamId);
});

l.addEventListener("click", () => {
    const teamId = 2;
    addStateAndShowTeam(teamId);
});

function addStateAndShowTeam(teamId) {
    history.pushState({ teamId }, "", `#/team/${teamId}`);
    showTeam(teamId);
}

function showTeam(id) {
    const team = teams.find(team => team.id === id);

    if (team) {
        teamContent.innerHTML = `
        <h1>Title: ${team.title}</h1>
        <h1>Manager: ${team.manager}</h1>
        <h1>Name: ${team.fullName}</h1>
        `;
    }
}

window.addEventListener("popstate", ({ state }) => {
    if (!state) {
        teamContent.innerHTML = "Try again, please...";
    }

    const { teamId } = state;
    showTeam(teamId);
});