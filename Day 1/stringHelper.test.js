const { findFirstDigit, findLastDigit, reverseString, replaceLetterNumbers } = require('./stringHelper');

test('reverse "pqr3stu8vwx" should produce "xwv8uts3rqp"', () => {
    const result = reverseString('pqr3stu8vwx');
    expect(result).toBe('xwv8uts3rqp');
});

test('find first digit of "pqr3stu8vwx" should return 3', () => {
    const result = findFirstDigit('pqr3stu8vwx');
    expect(result).toBe(3);
});

test('find last digit of "pqr3stu8vwx" should return 8', () => {
    const result = findLastDigit('pqr3stu8vwx');
    expect(result).toBe(8);
});

test.each([
    ['two1nine', '219'],
    ['eightwothree', '8wo3'],
    ['abcone2threexyz', 'abc123xyz'],
    ['xtwone3four', 'x2ne34'],
    ['4nineeightseven2', '49872'],
    ['zoneight234', 'z1ight234'],
    ['7pqrstsixteen', '7pqrst6teen']
])('replace number with letters like %s should output value %s', (line, expected) => {
    const result = replaceLetterNumbers(line);
    expect(result).toBe(expected);
})

test('replace letters numbers for value "oneight" should output 1ight', () => {
    const result = replaceLetterNumbers('oneight');
    expect(result).toBe('1ight');
});

test('replace letters numbers for value "oneight" with isRightToLeft should output on8', () => {
    const result = replaceLetterNumbers('oneight', true);
    expect(result).toBe('on8');
});