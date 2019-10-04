const {expect} = require('chai');

it('Expected 2 + 2 to be equal to 4', () => {
    // Arange
    const expected = 4;

    // Act
    const result = 2 + 2;

    // Assert
    expect(result).to.be.equal(expected);
});