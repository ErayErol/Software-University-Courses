let expect = require('chai').expect;
const createCalculator = require('../app');

describe('Test Add and Subtract', function () {

   let calc;

   beforeEach(function () {
      calc = createCalculator();
   });

   describe('Function tests - checks if it is a function', function () {
      it('should be a function', function () {
         let actual = typeof calc;
         let expected = 'object';

         expect(actual).to.equal(expected);
      });
   });

   describe('Zero value when created', function () {
      it('should zero value when created', function () {
         let actual = calc.get();
         let expected = 0;

         expect(actual).to.equal(expected);
      });
   });

   describe('Check add function', function () {
      it('value should be 5', function () {
         calc.add(5);

         let actual = calc.get();
         let expected = 5;

         expect(actual).to.equal(expected);
      });
   });

   describe('Check subtract function', function () {
      it('value should be 10', function () {
         calc.add(15);
         calc.add(5);
         calc.subtract(10);

         let actual = calc.get();
         let expected = 10;

         expect(actual).to.equal(expected);
      });
   });

   describe('NaN when value is string', function () {
      it('result should be NaN', function () {
         calc.add('foo');
         calc.add('bar');

         let actual = calc.get();

         expect(actual).to.be.NaN;
      });
   });

   describe('When input number is string', function () {
      it('value should be 10', function () {
         calc.add('15');
         calc.add('5');
         calc.subtract('10');

         let actual = calc.get();
         let expected = 10;

         expect(actual).to.equal(expected);
      });
   });

});