const assert = require('chai').assert;
const AutoService = require('../02. Auto Service_Ресурси');

describe('AutoService', function () {

    // it('should have the correct function properties', function () {
    //     assert.isFunction(AutoService.prototype.repairCar);
    //     assert.isFunction(AutoService.prototype.signUpForReview);
    //     assert.isFunction(AutoService.prototype.carInfo);
    // });

    it('1', function () {
        let autoService = new AutoService(2);
        let actual = autoService;
        let expected = { garageCapacity: 2, workInProgress: [], backlogWork: [] };

        assert.deepEqual(actual, expected);
    });

    it('2', function () {
        let autoService = new AutoService(2);
        let actual = autoService.availableSpace;
        let expected = 2;

        assert.deepEqual(actual, expected);
    });

    it('3', function () {
        let autoService = new AutoService(2);

        autoService.signUpForReview('Peter', 'CA1234CA', { 'engine': 'MFRGG23', 'transmission': 'FF4418ZZ', 'doors': 'broken' });
        autoService.signUpForReview('Peter', 'CA1234CA', { 'engine': 'MFRGG23', 'transmission': 'FF4418ZZ', 'doors': 'broken', 'wheels': 'broken', 'tires': 'broken' });
        autoService.signUpForReview('Philip', 'PB4321PB', { 'engine': 'MFRGG23', 'transmission': 'FF4418ZZ', 'exaustPipe': 'REMUS' });


        let actual = autoService.repairCar();
        let expected = 'Your doors were repaired.';

        assert.equal(actual, expected);
    });

    it('4', function () {
        let autoService = new AutoService(2);

        let actual = autoService.repairCar();
        let expected = 'No clients, we are just chilling...';

        assert.equal(actual, expected);
    });

    it('5', function () {
        let autoService = new AutoService(2);

        autoService.signUpForReview('Peter', 'CA1234CA', { 'engine': 'MFRGG23', 'transmission': 'FF4418ZZ', 'doors': 'broken', 'wheels': 'broken', 'tires': 'broken' });
        autoService.signUpForReview('Philip', 'PB4321PB', { 'engine': 'MFRGG23', 'transmission': 'FF4418ZZ', 'exaustPipe': 'REMUS' });


        let actual = autoService.carInfo('PB4321PB', 'Philip');
        let expected = {
            plateNumber: 'PB4321PB',
            clientName: 'Philip',
            carInfo: { engine: 'MFRGG23', transmission: 'FF4418ZZ', exaustPipe: 'REMUS' }
        };

        assert.deepEqual(actual, expected);
    });

    it('6', function () {
        let autoService = new AutoService(2);
        autoService.signUpForReview('Philip', 'PB4321PB', { 'engine': 'MFRGG23', 'transmission': 'FF4418ZZ', 'exaustPipe': 'REMUS' });

        let actual = autoService.repairCar();
        let expected = 'Your car was fine, nothing was repaired.';

        assert.equal(actual, expected);
    });

    it('7', function () {
        let autoService = new AutoService(2);
        autoService.signUpForReview('Philip', 'PB4321PB', { 'engine': 'MFRGG23', 'transmission': 'FF4418ZZ', 'exaustPipe': 'REMUS' });

        let actual = autoService.carInfo('X8688KA', 'Eray');
        let expected = 'There is no car with platenumber X8688KA and owner Eray.';

        assert.deepEqual(actual, expected);
    });

    it('8', function () {
        let autoService = new AutoService(2);

        autoService.signUpForReview('Peter', 'CA1234CA', { 'engine': 'MFRGG23', 'transmission': 'FF4418ZZ', 'doors': 'broken' });
        autoService.signUpForReview('Peter', 'CA1234CA', { 'engine': 'MFRGG23', 'transmission': 'FF4418ZZ', 'doors': 'broken', 'wheels': 'broken', 'tires': 'broken' });
        autoService.signUpForReview('Philip', 'PB4321PB', { 'engine': 'MFRGG23', 'transmission': 'FF4418ZZ', 'exaustPipe': 'REMUS' });

        let actual = `${autoService.carInfo('PB4321PB', 'Philip')}\n${autoService.carInfo('PB9999PB', 'PHILIP')}`;
        let expected = `[object Object]\nThere is no car with platenumber PB9999PB and owner PHILIP.`;

        assert.deepEqual(actual, expected);
    });
});