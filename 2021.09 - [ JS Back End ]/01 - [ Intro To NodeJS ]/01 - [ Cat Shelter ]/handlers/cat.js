const url = require('url');
const fs = require('fs');
const path = require('path');
const qs = require('querystring');
const formidable = require('formidable');
const cats = require('../data/cats');
const breeds = require('../data/breeds');

module.exports = (req, res) => {
    const pathname = url.parse(req.url).pathname;

    if (pathname === '/cats/add-cat' && req.method === 'GET') {
        let filePath = path.join(__dirname, '../views/addCat.html');

        const readStream = fs.createReadStream(filePath);
        // src.pipe(res);

        readStream.on("data", (data) => {
            res.write(data);
        });

        readStream.on("end", () => {
            res.end();
        });

        readStream.on("error", (err) => {
            res.write(err);
        });
    } else if (pathname === '/cats/add-cat' && req.method === 'POST') {
        let form = formidable.IncomingForm();

        form.parse(req, (err, fields, files) => {
            cats.push(fields);

            let result = JSON.stringify(cats, '', 2);

            let dbPath = path.join(__dirname, '/data/cats.json');

            fs.writeFileSync(dbPath, result, { encoding: "utf8" });

            res.end();
        });

    } else if (pathname === '/cats/add-breed' && req.method === 'GET') {
        let filePath = path.join(__dirname, '../views/addBreed.html');

        const src = fs.createReadStream(filePath);
        src.pipe(res);
    } else {
        return true;
    }
};