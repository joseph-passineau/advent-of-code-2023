const { findFirstDigit, reverseString } = require('./stringHelper');

class Calibrator {
    constructor() {
        this.Sum = 0;
    }

    calibrate(line) {
        const firstDigit = findFirstDigit(line)
        const lastDigit = findFirstDigit(reverseString(line));

        const lineValue = Number(`${firstDigit}${lastDigit}`)
        this.Sum += lineValue;

        return lineValue;
    }
}

module.exports = {
    Calibrator
};