const assert = require('chai').assert;
const BookStore = require('../02. Book Store_Ресурси');

describe('BookStore', function () {

    let store;
    this.beforeEach(function () {
        store = new BookStore('Store');
    });

    it('1', function () {
        let actual = store.hire('George', 'seller');
        let expected = 'George started work at Store as seller';

        assert.deepEqual(actual, expected);
    });

    it('2', function () {
        store.hire('Tom', 'juniorSeller');

        let actual = store.fire('Tom');
        let expected = 'Tom is fired';

        assert.deepEqual(actual, expected);
    });

    it('3', function () {
        store.stockBooks(['Inferno-Dan Braun', 'Harry Potter-J.Rowling', 'Uncle Toms Cabin-Hariet Stow', 'The Jungle-Upton Sinclear']);

        store.hire('George', 'seller');
        store.hire('Ina', 'seller');
        store.hire('Tom', 'juniorSeller');

        store.sellBook('Inferno', 'Ina');
        store.stockBooks(['Harry Potter-J.Rowling']);
        store.fire('Tom');

        let actual = store.printWorkers();
        let expected = 'Name:George Position:seller BooksSold:0\nName:Ina Position:seller BooksSold:1';

        assert.deepEqual(actual, expected);
    });

    it('4', function () {
        store.stockBooks(['Inferno-Dan Braun', 'Uncle Toms Cabin-Hariet Stow']);

        store.hire('George', 'seller');
        store.hire('Ina', 'seller');
        store.hire('Tom', 'juniorSeller');

        store.sellBook('Inferno', 'Ina');

        let actual = store.stockBooks(['Uncle Toms Cabin-Hariet Stow']);
        let expected = '[object Object],[object Object]';

        assert.equal(actual, expected);
    });

    it('5', function () {
        store.hire('Eray', "Junior");

        let actual = function () {
            store.hire('Eray', "Junior");
        };

        let expected = 'This person is our employee';

        assert.throws(actual, expected);
    });
});