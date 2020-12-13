import UserManager from '../infrastructure/userManager.js';
import BaseController from './baseController.js';
import LoginModel from '../models/loginModel.js';
import config from '../infrastructure/appSettings.js';
import * as toastr from 'toastr'; 

export default class AccountController extends BaseController {
    constructor(app){
        super(app);
        this.mustAuthenticate = false;
        this.userManager = new UserManager(app);
        this.userManager.setObserver(config.loginContainer);
    }

    async register() {
        await this.View('register');
    }

    async performRegister(registerModel){
        if (registerModel.repeatPassword !== registerModel.password) {
            toastr.error('Passwords must be equal!');
        } else {
            let user = await this.userManager
                .createUser(registerModel.username, registerModel.password);

        history.pushState({}, '', '/');
        }
    }
    
    async login(returnUrl = '/', state = {}) {
        if (typeof(returnUrl) !== 'string') {
            returnUrl = '/';
        }

        let loginModel = new LoginModel(returnUrl, state);
        await this.View('login', loginModel);
    }

    async executeLogin(loginModel){
        try {
            let user = await this.userManager
            .signIn(loginModel.username, loginModel.password);

        history.pushState({}, '', loginModel.returnUrl);
        } catch (error) {
            toastr.error('Invalid username or password!')
        }
    }

    async logout() {
        await this.userManager.signOut();

        history.pushState({}, '', '/');
    }
}