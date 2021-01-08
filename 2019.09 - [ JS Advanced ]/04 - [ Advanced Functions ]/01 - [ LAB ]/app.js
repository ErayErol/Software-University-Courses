import { data } from './MOCK_DATA.js';

(function teams(matches) {
    const app = document.getElementById('app');
    const display = document.createElement('div');

    let renderTeams = (parent, tag, context) => {
        context.score !== undefined
            ? parent.innerHTML += `<${tag}>${context.team1} ${context.score.ft[0]} : ${context.score.ft[1]} ${context.team2}</${tag}>`
            : parent.innerHTML += `<${tag}>${context.team1} : ${context.team2}</${tag}>`;
    };

    matches.map(match => renderTeams(display, "h3", match));

    app.appendChild(display);

})(data.matches.slice(79, 81));