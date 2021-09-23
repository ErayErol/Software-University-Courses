const path = require('path');
const express = require('express');
const app = express();
const handlebars = require('express-handlebars')
const port = 3000;

app.engine('.hbs', handlebars({
    extname: '.hbs'
}));

app.set('view engine', '.hbs');

app.get('/', (req, res) => {
    // let pathView = path.join(__dirname, "./views/addBreed.hbs");

    res.render('home', {layout : false});
});


app.listen(port, () => console.log(`Express running on port: ${port}...`));
