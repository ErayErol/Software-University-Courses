export default class BaseModel{
    constructor(){
        Object.defineProperty(this, 'id', {
            enumerable: false,
            writable: true,
            value: ''
        });
    }

    toEntity(){
        let value = Object.assign({}, this);
        return {
            id: this.id,
            value: value
        };
    }

    fromEntity(entity, id) {
        Object.assign(this, entity);
        this.id = id;
    }
}