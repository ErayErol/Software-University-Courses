const express = require('express');
const app = express.Router();
const fs = require('fs');
const path = require('path');
const breeds = require('../data/breeds.json');
const cats = require('../data/cats.json');
const upload = require('express-fileupload');
let bodyParser = require('body-parser');
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());
app.use(upload());

app.get('/add-breed', (req, res) => {
    res.render('addBreed', { layout: false });
});

app.post('/add-breed', (req, res) => {
    breeds.push(req.body.breed);
    const filePath = path.join(__dirname, '../data/breeds.json');
    let result = JSON.stringify(breeds);
    fs.writeFile(filePath, result, 'utf8', () => console.log('The breed was added successfully.'));
    res.redirect(302, '/');
});

app.get('/add-cat', (req, res) => {
    res.render('addCat', {
        layout: false,
        breeds,
    });
});

app.post('/add-cat', (req, res) => {
    let image = '';
    if (req.files) {
        let file = req.files.file;
        image = file.name;
        let filePath = path.join(__dirname, "../public/images/" + file.name,);

        file.mv(filePath, (err) => {
            if (err) {
                res.send(err);
            } else {
                console.log('Files was uploaded successfully.');
            }
        });
    } else {
        image = null;
    }

    let i = 1;
    while (true) {
        const id = cats.length + i;
        let isIdFree = cats.findIndex(cat => cat.id === id);

        if (isIdFree > -1) {
            i++;
        } else {
            cats.push({ id: id, ...req.body, image });
            break;
        }
    }

    let result = JSON.stringify(cats, '', 2);
    let resultPath = path.join(__dirname, '../data/cats.json');
    fs.writeFile(resultPath, result, 'utf8', () => console.log('The cat was added successfully.'));
    res.redirect(302, '/');
});

app.get('/edit/:id', (req, res) => {
    const catId = +req.params.id;
    let cat = cats.find(c => c.id === catId);

    res.render('editCat', {
        layout: false,
        cat,
        breeds,
    });
});

app.post('/edit/:id', (req, res) => {
    const catId = +req.params.id;
    let catIndex = cats.findIndex((cat => cat.id == catId));
    cats[catIndex].name = req.body.name;
    cats[catIndex].description = req.body.description;
    cats[catIndex].breed = req.body.breed;

    if (req.files) {
        let file = req.files.upload;
        let imagePath = path.join(__dirname, "../public/images/" + file.name,);

        file.mv(imagePath, (err) => {
            if (err) {
                res.send(err);
            } else {
                console.log('Files was uploaded successfully.');
            }
        });

        cats[catIndex].image = file.name;
    }

    let result = JSON.stringify(cats, '', 2);
    let filePath = path.join(__dirname, '../data/cats.json');
    fs.writeFile(filePath, result, 'utf8', () => console.log('The cat was edited successfully.'));
    res.redirect(302, '/');
});

app.get('/find-new-home/:id', (req, res) => {
    const catId = +req.params.id;
    let cat = cats.find(c => c.id === catId);

    res.render('catShelter', {
        layout: false,
        cat,
    });
});

app.post('/find-new-home/:id', (req, res) => {
    const catId = +req.params.id;
    let catIndex = cats.findIndex((cat => cat.id == catId));

    if (catIndex > -1) {
        cats.splice(catIndex, 1);
        let result = JSON.stringify(cats, '', 2);
        let filePath = path.join(__dirname, '../data/cats.json');
        fs.writeFile(filePath, result, 'utf8', () => console.log('The cat was deleted successfully.'));
    }

    res.redirect(302, '/');
});

module.exports = app;