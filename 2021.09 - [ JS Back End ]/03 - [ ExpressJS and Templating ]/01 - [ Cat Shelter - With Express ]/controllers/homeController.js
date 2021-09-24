const express = require('express');
const app = express.Router();
const cats = require('../data/cats.json');

app.get('/', (req, res) => {
    res.render('home', {
        layout: false,
        cats
    });
});

module.exports = app;