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

module.exports = {
    reverseString,
    findFirstDigit
};