const { findFirstDigit, findLastDigit, replaceLetterNumbers } = require('./stringHelper');

class Calibrator {
    constructor(shouldReplaceLetterNumbers = false) {
        this.shouldReplaceLetterNumbers = shouldReplaceLetterNumbers;
        this.Sum = 0;
    }

    calibrate(line) {
        const firstDigit = this.shouldReplaceLetterNumbers ? findFirstDigit(replaceLetterNumbers(line)) : findFirstDigit(line);
        const lastDigit = this.shouldReplaceLetterNumbers ? findLastDigit(replaceLetterNumbers(line, true)) : findLastDigit(line);

        const lineValue = Number(`${firstDigit}${lastDigit}`)
        this.Sum += lineValue;

        return lineValue;
    }
}

module.exports = {
    Calibrator
};