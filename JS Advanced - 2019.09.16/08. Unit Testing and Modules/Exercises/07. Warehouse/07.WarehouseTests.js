const expect = require('chai').expect;
const app = require('./07.Warehouse');

describe('Warehouse', function () {
    let warehouse;

    beforeEach(function () {
        warehouse = new Warehouse(5);
    });

    it('should give correct message for empty warehouse', function () {
        expect(warehouse.revision()).to.be.equal('The warehouse is empty');
    });
});

describe('Warehouse', () => {

    describe('Constructor Tests', () => {

        it('should throw string if givenSpace <= 0 or non-number argument',
            () => {

                expect(() => {
                    new Warehouse(-1);
                }).to.throw();
                expect(() => {
                    new Warehouse(0);
                }).to.throw();
                expect(() => {
                    new Warehouse("a");
                }).to.throw();
            });

        it('should throw string no free space is available', () => {
            let warehouse = new Warehouse(1);
            assert.throws(() => warehouse.addProduct('Food', 'bread', 2));
        });

        it('should sort foods in descending order by quantity', () => {
            let warehouse = new Warehouse(12);
            warehouse.addProduct('Food', 'bread', 1);
            warehouse.addProduct('Food', 'potatoes', 2);
            warehouse.addProduct('Food', 'mushrooms', 3);
            warehouse.orderProducts('Food');

            let foods = JSON.stringify(warehouse.availableProducts.Food);
            assert.equal(foods, '{\'mushrooms\':3,\'potatoes\':2,\'bread\':1}');
        });

        it('should return string \'The warehouse is empty\' for 0 products', () => {
            let warehouse = new Warehouse(4);
            expect(warehouse.revision()).to.be.equal('The warehouse is empty');
        });

        it('throw error for non existing type', function () {
            expect(() => {
                let warehouse = new Warehouse(5);
                warehouse.addProduct('Food', 'banana', 4);
                warehouse.addProduct('Food', 'apple', 1);
                warehouse.scrapeAProduct('tomato', 1);
            }).to.throw('tomato do not exists');
        });
    });
});