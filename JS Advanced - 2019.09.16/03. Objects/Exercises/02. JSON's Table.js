function jsonstable(input) {

    let html = `<table>\n`;
    for (let line of input) {
        html += `	<tr>\n`
        let split = JSON.parse(line);
        let name = split.name;
        let position = split.position;
        let salary = Number(split.salary);
        
        html += `		<td>${name}</td>\n`;
        html += `		<td>${position}</td>\n`;
        html += `		<td>${salary}</td>\n	</tr>\n`;
    }
    html += `</table>`;

    console.log(html);
}

jsonstable(['{"name":"Pesho","position":"Promenliva","salary":100000}',
    '{"name":"Teo","position":"Lecturer","salary":1000}',
    '{"name":"Georgi","position":"Lecturer","salary":1000}']
);