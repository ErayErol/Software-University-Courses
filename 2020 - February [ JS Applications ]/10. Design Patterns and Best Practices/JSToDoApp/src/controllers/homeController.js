import BaseController from './baseController.js';
import Repository from '../infrastructure/repository.js';
import config from '../infrastructure/appSettings.js';

export default class HomeController extends BaseController {
    constructor(app) {
        super(app);
        this.mustAuthenticate = false;
        this.errorRepo = new Repository(config.dataCollections.errorLogCollection);
    }

    async index() {
        await this.View('home');
    }

    async notFound(data) {
        await this.View('notFound', data);
    }

    async logError(data) {
        this.errorRepo.add(data);
        await this.View('error', data);
    }
}