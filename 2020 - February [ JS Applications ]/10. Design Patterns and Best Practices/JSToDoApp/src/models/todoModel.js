import BaseModel from './baseModel.js';

export default class TodoModel extends BaseModel {
    constructor(model){
        super();
        if (model) {
            this.id = model.id || '';
            this.description = model.description || '';
            this.isCompleted = !!model.isCompleted;
            this.userId = model.userId || '';
        } else {
            this.description = '';
            this.isCompleted = false;
            this.userId = '';
        }
    }
}