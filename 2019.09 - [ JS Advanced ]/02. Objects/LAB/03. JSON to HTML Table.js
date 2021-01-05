function solve(input) {
    String.prototype.htmlEscape = function () {
        return this.replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    };

    let keys = [];
    let table = JSON.parse(input);

    let result = `<table>\n   <tr>`;
    for (const obj of table) {
        for (const key in obj) {
            if (obj.hasOwnProperty(key)) {
                result += `<th>${key.htmlEscape()}</th>`;
                keys.push(key.htmlEscape());
            }
        }
        break;
    }
    result += `</tr>\n`;

    for (let i = 0; i < table.length; i++) {
        result += `   <tr>`;

        for (let j = 0; j < keys.length; j++) {
            let element = table[i][keys[j]];

            if (Number(element)) {
                result += `<td>${element}</td>`;
            } else {
                result += `<td>${element.htmlEscape()}</td>`;
            }
        }

        result += `</tr>\n`;
    }

    result += '</table>';
    console.log(result);
}

solve(['[{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]']);

solve(['[{"Name":"Pesho <div>-a","Age":20,"City":"Sofia","Sex":"Male"},{"Name":"Gosho","Age":18,"City":"Plovdiv","Sex":"Female"}]']);