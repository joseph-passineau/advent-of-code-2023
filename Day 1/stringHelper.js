const NUMBERS_WITH_LETTERS = {'one': 1, 'two': 2, 'three': 3, 'four': 4, 'five': 5, 'six': 6, 'seven': 7, 'eight': 8, 'nine': 9};

function reverseString(stringValue) {
    const splitString = stringValue.split("");
    return splitString.reverse().join("");
}

function findFirstDigit(stringValue) {
    const splitString = stringValue.split("");
    for(const character of splitString) {
        var number = parseInt(character);
        if(!isNaN(number)){
            return number;
        }
    };
}

function replaceLetterNumbers(stringValue, isRightToLeft = false) {
    const splitString = isRightToLeft ? stringValue.split("").reverse() : stringValue.split("");
    let newStringValue = '';
    
    for(const character of splitString) {
        if(isRightToLeft) {
            newStringValue = character + newStringValue;
        }
        else {
            newStringValue = newStringValue + character;
        }
        for (const [key, value] of Object.entries(NUMBERS_WITH_LETTERS)) {
            newStringValue = newStringValue.replace(key, value);
        }
    }

    return newStringValue;
}

module.exports = {
    reverseString,
    findFirstDigit,
    replaceLetterNumbers
};