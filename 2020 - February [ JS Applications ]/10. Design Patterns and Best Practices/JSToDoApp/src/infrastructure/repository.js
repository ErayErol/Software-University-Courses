import appSettings from './appSettings.js';
import HttpRequester from './httpRequester.js';

export default class Repository {
    constructor(collection){
        this.collection = collection;
        this.requester = new HttpRequester(appSettings.baseUrl);
    }

    async getAll(){
        let url = `${this.collection}.json`;

        return this.requester.get(url);
    }

    async getById(id){
        let url = `${this.collection}/${id}.json`;

        return this.requester.get(url);
    }

    async add(entity){
        let url = `${this.collection}.json`;

        return this.requester.post(url, entity);
    }

    async update(entity, partial = false){
        if (!entity.id) {
            throw new Error('Entity must have identificator');
        }

        let url = `${this.collection}/${entity.id}.json`;

        if (partial) {
            return this.requester.patch(url, entity.value);
        }

        return this.requester.put(url, entity.value);
    }

    async delete(id){
        let url = `${this.collection}/${id}.json`;

        return this.requester.delete(url);
    }
}