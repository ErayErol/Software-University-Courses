const assert = require('chai').assert;
const PaymentPackage = require('../app');

describe('PaymentPackage', function () {

    it('should initialized with correct toString and change VAT and', function () {
        let pp = new PaymentPackage('JS', 0);
        pp.VAT = 0;
        let actual = pp.toString();
        let expected = 'Package: JS\n- Value (excl. VAT): 0\n- Value (VAT 0%): 0';

        assert.equal(actual, expected);
    });

});