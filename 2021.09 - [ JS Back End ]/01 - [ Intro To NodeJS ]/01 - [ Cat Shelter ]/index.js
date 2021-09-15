const http = require('http');
const port = 5000;

let app = http.createServer((req, res) => {
    res.writeHead(200, { 'Content-Type': 'text/plain' });
    res.write('Hello Node.js');
    res.end();
});

app.listen(port);

console.log(`Node.js server running on port ${port}`);