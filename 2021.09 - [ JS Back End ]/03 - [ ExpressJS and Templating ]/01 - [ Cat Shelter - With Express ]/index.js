const port = 3000;
const express = require('express');
let app = express();

const path = require('path');
const handlebars = require('express-handlebars');

const catsController = require('./controllers/catsController.js');
const homeController = require('./controllers/homeController.js');

app.use(express.static('./public'));

app.engine('.hbs', handlebars({
    extname: '.hbs',
    partialsDir: [
        //  path to your partials
        path.join(__dirname, 'views/partials'),
    ]
}));

app.set('view engine', '.hbs');

app.use('/cats', catsController);
app.use('/', homeController);

app.listen(port, () => console.log(`Express running on port: ${port}...`));
