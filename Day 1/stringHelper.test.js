const { findFirstDigit, reverseString } = require('./stringHelper');

test('reverse pqr3stu8vwx should produce xwv8uts3rqp', () => {
    const result = reverseString('pqr3stu8vwx');
    expect(result).toBe('xwv8uts3rqp');
});

test('find first digit of pqr3stu8vwx should return 3', () => {
    const result = findFirstDigit('pqr3stu8vwx');
    expect(result).toBe(3);
});