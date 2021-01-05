import TemplateEngine from '../infrastructure/templateEngine.js';
import appSettings from '../infrastructure/appSettings.js';
import UserManager from '../infrastructure/userManager.js';

export default class BaseController {
    constructor(app) {
        this.mustAuthenticate = true;
        this.userManager = new UserManager(app);
        this.templateEngine = new TemplateEngine();
        this.contentContainer = document.getElementById(appSettings.contentContainerId);
    }

    get currentUser(){
        return this.userManager.getCurrentUser();
    }

    async View(name, model) {
        let path = `/dist/views/${name}.html`;
        const response = await fetch(path, {mode: 'no-cors'});
        if (response.status >= 400) {
            throw new Error(response);
        }
        
        const templateText = await response.text();
        const template = this.templateEngine.compile(templateText);

        this.contentContainer.innerHTML = template(model || {});
    }

    
}