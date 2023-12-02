const fs = require('fs');
const readline = require('readline');
const { Calibrator } = require('./calibrator');

const calibrator = new Calibrator();
const calibratorV2 = new Calibrator(true);

const lineReader = readline.createInterface({
    input: fs.createReadStream('input.txt'),
    crlfDelay: Infinity
});

lineReader.on('line', (line) => {
    calibrator.calibrate(line);
    calibratorV2.calibrate(line);
});

lineReader.on('close', () => {
    console.log('Calibration result:', calibrator.Sum)
    console.log('Calibration v2 result:', calibratorV2.Sum)
})
