import Repository from '../infrastructure/repository.js';
//import Repository from '../infrastructure/fbRepository.js';
import BaseController from './baseController.js';
import config from '../infrastructure/appSettings.js';
import TodoModel from '../models/todoModel.js';
import * as toastr from 'toastr'; 

export default class TodoController extends BaseController {
    constructor(app) {
        super(app);
        this.repo = new Repository(config.dataCollections.todoCollection);
    }

    async index(){
        let res = await this.repo.getAll();
        let model = {
            todos: Array.from(Object.entries(res))
                .map((e) => {
                    let todo = new TodoModel();
                    todo.fromEntity(e[1], e[0]);
                    
                    return todo;                        
                })
                .filter((e) => e.userId === this.currentUser.uid)
        };
        
        await this.View('todoIndex', model);
    }

    async add(){
        const model = new TodoModel();
        await this.View('todoEdit', model);
    }

    async edit(todoId){
        const entity = await this.repo.getById(todoId.id);
        const model = new TodoModel();
        model.fromEntity(entity, todoId.id);
        model.isCompleted = model.isCompleted ? 'checked' : '';
        
        await this.View('todoEdit', model);
    }

    async performEdit(model){
        const todo = new TodoModel(model);
        let result;
        if (todo.id !== '') {
            const entity = todo 
            .toEntity();

            result = await this.repo.update(entity);
        } else {
            todo.userId = this.currentUser.uid;

            result = await this.repo.add(todo.toEntity().value);
        }

        toastr.success('Item saved successfully!');
        history.pushState(result, '', '/todo/index');
    }

    async delete(todoId){
        let result = await this.repo.delete(todoId.id);

        toastr.success('Item is deleted!');
        history.pushState(result, '', '/todo/index');
    }

    async markComplete(todoId){
        let result = await this.repo.update({
            id: todoId.id,
            value: { isCompleted: true }
        }, true);

        toastr.success('Item is completed!');
        history.pushState(result, '', '/todo/index');
    }
}