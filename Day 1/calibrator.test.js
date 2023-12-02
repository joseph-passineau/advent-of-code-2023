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

test('calibrator sum should sum up', () => {
    const calibrator = new Calibrator();
    calibrator.calibrate('1abc2');
    calibrator.calibrate('pqr3stu8vwx');
    calibrator.calibrate('a1b2c3d4e5f');
    calibrator.calibrate('treb7uchet');

    expect(calibrator.Sum).toBe(142);
});