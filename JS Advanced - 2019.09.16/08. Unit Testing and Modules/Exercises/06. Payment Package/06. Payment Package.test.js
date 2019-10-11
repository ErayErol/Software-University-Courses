const PaymentPackage = require('./06. Payment Package');
const assert = require('chai').assert;

describe('PaymentPackage', function () {

    it('should initialized with correct name and value', function () {
        let pp = new PaymentPackage('JS', 10);
        let actual = 'JS';
        let expected = pp.name;

        assert.equal(actual, expected);
    });

    it('shouldn\'t initialized with incorrect name', function () {
        let actual = function () {
            let pp = new PaymentPackage(10, 'CSS');
        };
        let expected = 'Name must be a non-empty string';

        assert.throws(actual, expected);
    });

    it('shouldn\'t initialized with incorrect value', function () {
        let actual = function () {
            let pp = new PaymentPackage('JS', 'CSS');
        };
        let expected = 'Value must be a non-negative number';

        assert.throws(actual, expected);
    });

    it('throw error when change VAT to negative number', function () {
        let actual = function () {
            let pp = new PaymentPackage('JS', 10);
            pp.VAT = -6;
        };
        let expected = 'VAT must be a non-negative number';

        assert.throws(actual, expected);
    });

    it('should initialized with correct VAT', function () {
        let pp = new PaymentPackage('JS', 10);
        let actual = 20;
        let expected = pp.VAT;

        assert.equal(actual, expected);
    });

    it('throw error when change active to negative number', function () {
        let actual = function () {
            let pp = new PaymentPackage('JS', 10);
            pp.active = -6;
        };
        let expected = 'Active status must be a boolean';

        assert.throws(actual, expected);
    });

    it('should initialized with correct active', function () {
        let pp = new PaymentPackage('JS', 10);
        let actual = true;
        let expected = pp.active;

        assert.equal(actual, expected);
    });

    it('should initialized with correct toString', function () {
        let pp = new PaymentPackage('JS', 10);
        let actual = pp.toString();
        let expected = 'Package: JS\n- Value (excl. VAT): 10\n- Value (VAT 20%): 12';

        assert.equal(actual, expected);
    });

    it('should initialized with correct toString and change active', function () {
        let pp = new PaymentPackage('JS', 10);
        pp.active = false;
        let actual = pp.toString();
        let expected = 'Package: JS (inactive)\n- Value (excl. VAT): 10\n- Value (VAT 20%): 12';

        assert.equal(actual, expected);
    });

    it('should initialized with correct toString and change VAT', function () {
        let pp = new PaymentPackage('JS', 10);
        pp.VAT = 0;
        let actual = pp.toString();
        let expected = 'Package: JS\n- Value (excl. VAT): 10\n- Value (VAT 0%): 10';

        assert.equal(actual, expected);
    });

    it('should initialized with correct toString and change VAT to 0', function () {
        let pp = new PaymentPackage('JS', 0);
        pp.VAT = 0;
        let actual = pp.toString();
        let expected = 'Package: JS\n- Value (excl. VAT): 0\n- Value (VAT 0%): 0';

        assert.equal(actual, expected);
    });

});