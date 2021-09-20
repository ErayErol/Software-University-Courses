const url = require('url');
const fs = require('fs');
const path = require('path');
const qs = require('querystring');
const formidable = require('formidable');
const cats = require('../data/cats');
const breeds = require('../data/breeds');
const { UV_FS_O_FILEMAP } = require('constants');

module.exports = (req, res) => {
    const pathname = url.parse(req.url).pathname;

    if (pathname === '/cats/add-cat' && req.method === 'GET') {
        const filePath = path.join(__dirname, '../views/addCat.html');

        const readStream = fs.createReadStream(filePath);

        readStream.on("data", (data) => {

            let catBreedPlaceholder = breeds.map(breed => `
                <option value="${breed}">${breed}</option>
            `);

            let modifiedData = data.toString().replace('{{catBreeds}}', catBreedPlaceholder);

            res.write(modifiedData);
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
            if (err) {
                throw err;
            }
            
            let oldPath = files.upload.path.toString();
            let newPath = path.join(__dirname, '../content/images/' + files.upload.name);
            
            fs.copyFile(oldPath, newPath, (err) => {
                if (err) {
                    throw err;
                }

                console.log('Files was uploaded successfully.');
            });

            cats.push({ id: cats.length + 1, ...fields, image: files.upload.name });
            let result = JSON.stringify(cats, '', 2);

            let filePath = path.join(__dirname, '../data/cats.json');

            fs.writeFile(filePath, result, 'utf8', () => {
                console.log('The cat was added successfully.');
            });

            res.writeHead(302, { location: '/' });
            res.end();
        });

    } else if (pathname === '/cats/add-breed' && req.method === 'GET') {
        const filePath = path.join(__dirname, '../views/addBreed.html');
        const src = fs.createReadStream(filePath);
        src.pipe(res);
    } else if (pathname === '/cats/add-breed' && req.method === 'POST') {
        let formData = '';

        req.on('data', (data) => {
            formData += data;
        });

        req.on('end', () => {
            const filePath = path.join(__dirname, '../data/breeds.json');
            let body = qs.parse(formData);

            fs.readFile(filePath, (err, data) => {
                if (err) {
                    throw err;
                }

                let breeds = JSON.parse(data);
                breeds.push(body.breed);
                let result = JSON.stringify(breeds);

                fs.writeFile(filePath, result, 'utf8', () => {
                    console.log('The breed was added successfully.');
                });
            });

            res.writeHead(302, { location: '/' });
            res.end();
        });
    } else {
        return true;
    }
};