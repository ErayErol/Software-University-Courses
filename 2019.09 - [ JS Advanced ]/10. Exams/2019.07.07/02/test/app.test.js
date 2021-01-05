const assert = require('chai').assert;
const PizzUni = require('../02. PizzUni_Ресурси');

describe('PizzUni', function () {

    let pi;
    beforeEach(function () {
        pi = new PizzUni();
    });

    it('1', function () {
        let actual = pi;
        let expected = {
            registeredUsers: [],
            availableProducts: {
              pizzas: [ 'Italian Style', 'Barbeque Classic', 'Classic Margherita' ],
              drinks: [ 'Coca-Cola', 'Fanta', 'Water' ]
            },
            orders: []
          };

        assert.deepEqual(actual, expected);
    });

    it('2', function () {
        let actual = pi.availableProducts['pizzas'];
        let expected = [ 'Italian Style', 'Barbeque Classic', 'Classic Margherita' ];

        assert.deepEqual(actual, expected);
    });
    
});