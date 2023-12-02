const { Calibrator } = require('./calibrator');

test.each([
    ['1abc2', 12],
    ['pqr3stu8vwx', 38],
    ['a1b2c3d4e5f', 15],
    ['treb7uchet', 77]
])('calibrating %s should output value %i', (line, expected) => {
    const calibrator = new Calibrator();
    expect(calibrator.calibrate(line)).toBe(expected);
})

test('calibrator sum should be 142', () => {
    const calibrator = new Calibrator();
    calibrator.calibrate('1abc2');
    calibrator.calibrate('pqr3stu8vwx');
    calibrator.calibrate('a1b2c3d4e5f');
    calibrator.calibrate('treb7uchet');

    expect(calibrator.Sum).toBe(142);
});

test('calibrator with shouldReplaceLetterNumbers sum should be 281', () => {
    const calibrator = new Calibrator(true);
    calibrator.calibrate('two1nine');
    calibrator.calibrate('eightwothree');
    calibrator.calibrate('abcone2threexyz');
    calibrator.calibrate('xtwone3four');
    calibrator.calibrate('4nineeightseven2');
    calibrator.calibrate('zoneight234');
    calibrator.calibrate('7pqrstsixteen');

    expect(calibrator.Sum).toBe(281);
});

test.each([
    ['two1nine', 29],
    ['eightwothree', 83],
    ['abcone2threexyz', 13],
    ['xtwone3four', 24],
    ['4nineeightseven2', 42],
    ['zoneight234', 14],
    ['7pqrstsixteen', 76]
])('calibrating and replacing letter numbers %s should output value %i', (line, expected) => {
    const calibrator = new Calibrator(true);
    expect(calibrator.calibrate(line)).toBe(expected);
})