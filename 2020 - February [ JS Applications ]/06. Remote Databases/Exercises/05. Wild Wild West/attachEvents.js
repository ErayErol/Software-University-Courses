import { get, post, put, del } from "../requester.js";
import { loadCanvas } from "./loadCanvas.js";

const elements = {
    $addNameInput: () => document.getElementById("addName"),
    $addPlayer: () => document.getElementById("addPlayer"),
    $players: () => document.getElementById("players"),
    $save: () => document.getElementById("save"),
    $reload: () => document.getElementById("reload"),
    $canvas: () => document.getElementById("canvas"),
};

loadPlayers(null);
elements.$addPlayer().addEventListener("click", add);

async function loadPlayers(event) {
    cleaner();
    if (event) {
        event.preventDefault();
    }
    const players = await get("appdata", "players");
    for (const player of players) {
        showPlayers(player);
    }
}

async function add(event) {
    event.preventDefault();
    const data = getData(elements.$addNameInput().value, 500, 6);
    const player = await post("appdata", "players", data);
    showPlayers(player);
    clearInput();
}

function getData(name, money, bullets) {
    return { name, money, bullets, };
}

function cleaner() {
    elements.$players().innerHTML = '';
}

function clearInput() {
    elements.$addNameInput().value = '';
}

function showPlayers(player) {
    createPlayer(player);

    function createPlayer(player) {
        const { _id, name, money, bullets } = player;
        let fieldset = document.createElement("fieldset");
        fieldset.className = "player-fieldset";
        fieldset.setAttribute("data-id", _id);
        fieldset.innerHTML = `<span>Name:${name}</span> <br>
                            <span>Money:${money}</span> <br>
                            <span>Bullets:${bullets}</span> <br>
                            <button>Play</button> <br>
                            <button>Delete</button>`;
        const playPlayer = fieldset.elements[0];
        const delPlayer = fieldset.elements[1];
        playPlayer.addEventListener('click', playingGame);
        delPlayer.addEventListener('click', deletePlayer);
        elements.$players().append(fieldset);

        async function deletePlayer(event) {
            event.preventDefault();
            await del("appdata", `players/${_id}`);
            event.currentTarget.parentNode.remove();
        }

        function playingGame(e) {
            showOrHide("block");
            loadCanvas(player);

            elements.$reload().addEventListener("click", reload);
            elements.$save().addEventListener("click", save);

            function reload() {
                player.money -= 60;
                player.bullets = 6;
            }

            async function save() {
                const data = getData(player.name, player.money, player.bullets);
                await put("appdata", `player/${_id}`, data);
                const currentPlayer = [...elements.$players().children].find(x => x.dataset.id === _id);
                const oldResults = [...currentPlayer.children].filter(z => z.tagName === 'SPAN');
                for (let i = 0; i < oldResults.length; i++) {
                    let text = `${oldResults[i].textContent.split(":")[0]}:${data[Object.keys(data)[i]]}`;
                    oldResults[i].textContent = text;
                }
                showOrHide("none");
            }

            function showOrHide(command) {
                elements.$canvas().style.display = command;
                elements.$save().style.display = command;
                elements.$reload().style.display = command;
            }
        }
    }
}