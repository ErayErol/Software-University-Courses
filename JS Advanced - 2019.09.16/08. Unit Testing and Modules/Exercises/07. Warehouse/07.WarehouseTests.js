const expect = require('chai').expect;
const app = require('./07.Warehouse');
const Warehouse = app.Warehouse;

describe('Test Warehouse class', () => {
    let warehouse;

    beforeEach(() => {
        warehouse = new Warehouse(1000);
    });

    it('constructor sets capacity correctly', () => {
        let actual = warehouse.capacity;
        let expected = 1000;
        expect(actual).to.be.equal(actual, 'constructor does not work correctly');
    });

    it('constructor sets availableProducts  correctly', () => {
        expect(Object.keys(warehouse.availableProducts).length).to.be.equal(2, 'constructor does not work correctly');
        expect(Object.keys(warehouse.availableProducts['Food']).length).to.be.equal(0, 'constructor does not work correctly');
    });

    it('test constructor do not initialize and throw error with no parameters', ()=>{
        let err = 'Invalid given warehouse space';
        expect(function(){new Warehouse()}).to.throw(err, 'constructor do not work correctly with no parameter');
    });

    it('test constructor do not initialize and throw error invalid parameters', ()=>{
        let err = 'Invalid given warehouse space';
        expect(function(){new Warehouse(-2)}).to.throw(err, 'constructor do not work correctly with no parameter');
    });

    it('test constructor do not initialize and throw error invalid parameters', ()=>{
        let err = 'Invalid given warehouse space';
        expect(function(){new Warehouse('string')}).to.throw(err, 'constructor do not work correctly with no parameter');
    });

    it('set and get capacity works correctly with valid parameter', () => {
        warehouse.capacity = 2;
        let actual = warehouse.capacity;
        let expected = 2;
        expect(actual).to.be.equal(expected, 'set and get capacity does not work correctly');
    });

    it('set capacity throws and error with non-numeric parameter', () => {
        var err = `Invalid given warehouse space`;
        expect(function(){warehouse.capacity = 'string'}).to.throw(err, 'set does not throw an error');
    });

    it('set capacity throws and error with negative parameter', () => {
        var err = `Invalid given warehouse space`;
        expect(function(){warehouse.capacity = -2}).to.throw(err, 'set does not throw an error');
    });

    it('test addProduct works correctly with valid parameters', () => {
        warehouse.addProduct('Food', 'bread', 2);
        let actual = warehouse.availableProducts['Food']['bread'];
        let expected = 2;
        expect(actual).to.be.equal(expected, 'addProduct failed');
    });

    it('test addProduct works correctly with valid parameters', () => {
        warehouse.addProduct('Drink', 'boza', 20);
        let actual = warehouse.availableProducts['Drink']['boza'];
        let expected = 20;
        expect(actual).to.be.equal(expected, 'addProduct failed');
    });

    it('test addProduct throws an Error with exided quantity', () => {
        let err = `There is not enough space or the warehouse is already full`;
        expect(function(){warehouse.addProduct('Food', 'bread', 20000)}).to.throw(err, 'addProduct does not throw Error');
    });

    it('test addProduct increase product quantity', () => {
        warehouse.addProduct('Food', 'snack', 5);
        warehouse.addProduct('Food', 'snack', 5);
        let actual = warehouse.availableProducts['Food']['snack'];
        let expected = 10;
        expect(actual).to.be.equal(expected, 'addProduct failed');
    });

    it('test addProduct return the object correctly', () => {
        ;
        let actual = warehouse.addProduct('Food', 'snack', 5);
        
        expect(typeof actual).to.be.equal('object', 'addProduct failed');
    });

    it('test orderProducts with existing type product', () => {
        warehouse.addProduct('Food', 'bread', 5);
        warehouse.addProduct('Food', 'apples', 2);
        
        warehouse.orderProducts('Food');

        let actual = Object.keys(warehouse.availableProducts['Food'])[0];
        let expected = 'bread';

        expect(actual).to.be.equal(expected, 'orderProduct does not order products correctly')
    });

    it('test occupiedCapacity works properly', () => {
        warehouse.addProduct('Food', 'bread', 5);
        warehouse.addProduct('Drink', 'vodka', 45);

        let actual = warehouse.occupiedCapacity();
        let expected = 50;
        expect(actual).to.be.equal(expected, 'occupiedCapacity does not work correctly')
    });

    it('test occupedCapacity returns 0 if empty', ()=> {
        expect(warehouse.occupiedCapacity()).to.be.equal(0);
    })

    it('test revision return Error with empty Capacity', () => {
        let actual = warehouse.revision();
        let expected = 'The warehouse is empty';
        expect(actual).to.be.equal(expected,'set does not return an error');
    });

    it('test revison returns the correct message', ()=> {
        warehouse.addProduct('Food', 'bread', 5);
        warehouse.addProduct('Drink', 'boza', 15);

        let actual = warehouse.revision();
        let expected = 
        'Product type - [Food]' +
        '\n- bread 5' +
        '\nProduct type - [Drink]' +
        '\n- boza 15' 

        expect(actual).to.be.equal(expected, 'revision does not return correct message');
    });

    it('test scrapeAProduct with valid parameters', () => {
        warehouse.addProduct('Food', 'bread', 5);
        warehouse.scrapeAProduct('bread', 3);
        let actual = warehouse.availableProducts['Food']['bread'];
        let expected = 2;
        expect(actual).to.be.equal(expected, 'scrapeAProduct with valid parameters works bad');
    });

    it('test scrapeAProduct with valid product and bigger quantity', () => {
        warehouse.addProduct('Food', 'bread', 5);
        warehouse.scrapeAProduct('bread', 8);
        let actual = warehouse.availableProducts['Food']['bread'];
        let expected = 0;
        expect(actual).to.be.equal(expected, 'scrapeAProduct with bigger quantity works bad');
    });

    it('test scrapeAProduct with invalid product throws and Error', () => {
        warehouse.addProduct('Food', 'bread', 5);
        let err = `banana do not exists`;
        expect(function(){warehouse.scrapeAProduct('banana', 3);}).to.throw(err, 'scrapeAProduct does not throw Error');
    });
});