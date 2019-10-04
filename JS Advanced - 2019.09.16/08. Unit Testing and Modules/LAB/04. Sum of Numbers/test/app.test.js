let expect = require("chai").expect;
let rgbToHexColor = require("../app");

describe('rgbToHexColor', function () {

    it('When input is number.', () => {
        let expected = '#010203';
        let actual = rgbToHexColor(1, 2, 3);
        expect(actual).to.equal(expected);
    });

    it('When input is not number.', () => {
        let actual = rgbToHexColor('js', 66, 6);
        expect(actual).to.be.undefined;
    });

    it('When input is more than 255.', () => {
        let actual = rgbToHexColor(666, 66, 6);
        expect(actual).to.be.undefined;
    });

    it('When input is less than 0.', () => {
        let actual = rgbToHexColor(-6, 66, 6);
        expect(actual).to.be.undefined;
    });

    it('When input length is less than 3.', () => {
        let actual = rgbToHexColor(66, 6);
        expect(actual).to.be.undefined;
    });

    it('When input length is more than 3.', () => {
        let actual = rgbToHexColor(66, 6, 16, 166);
        expect(actual).to.be.undefined;
    });

    it('When input is number like string.', () => {
        let actual = rgbToHexColor('66', '6', '16');
        expect(actual).to.be.undefined;
    });

    it('When input is 0.', () => {
        let expected = '#000000';
        let actual = rgbToHexColor(0, 0, 0);
        expect(actual).to.equal(expected);
    });

    it('When input is 255.', () => {
        let expected = '#FFFFFF';
        let actual = rgbToHexColor(255, 255, 255);
        expect(actual).to.equal(expected);
    });
});