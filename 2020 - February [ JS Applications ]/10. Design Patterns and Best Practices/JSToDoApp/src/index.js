import appSettings from './infrastructure/appSettings.js';
import * as firebase from 'firebase/app';
import AccountController from './controllers/accountController.js';
import HomeController from './controllers/homeController.js';
import TodoController from './controllers/todoController.js';
import Router from './infrastructure/router.js';


var app = firebase.initializeApp(appSettings.firebaseConfig);
var controllers = {
    account: new AccountController(app),
    todo: new TodoController(app),
    home: new HomeController(app)
};

var router = new Router(controllers);
router.initialize();