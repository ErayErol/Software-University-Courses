function solve(input) {

    String.prototype.htmlEscape = function () {
        return this.replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    };

    let result = "<table>\n  <tr><th>name</th><th>score</th></tr>\n";
    let table = JSON.parse(input);

    for (let record of table) {
        result += `  <tr><td>${record.name.htmlEscape()}</td><td>${record.score}</td></tr>\n`;
    }

    result += "</table>";

    console.log(result);
}

solve(['[{"name":"Pesho","score":479},{"name":"Gosho","score":205}]']);

solve(['[{"name":"Pesho & Kiro", "score":479},{"name":"Gosho, Maria & Viki","score":205}]']);