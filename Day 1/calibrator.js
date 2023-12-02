const { findFirstDigit, reverseString, replaceLetterNumbers } = require('./stringHelper');

class Calibrator {
    constructor(shouldReplaceLetterNumbers = false) {
        this.shouldReplaceLetterNumbers = shouldReplaceLetterNumbers;
        this.Sum = 0;
    }

    calibrate(line) {
        const firstDigit = this.shouldReplaceLetterNumbers ? findFirstDigit(replaceLetterNumbers(line)) : findFirstDigit(line);
        const lastDigit = this.shouldReplaceLetterNumbers ? findFirstDigit(reverseString(replaceLetterNumbers(line, true))) : findFirstDigit(reverseString(line));

        const lineValue = Number(`${firstDigit}${lastDigit}`)
        this.Sum += lineValue;

        return lineValue;
    }
}

module.exports = {
    Calibrator
};