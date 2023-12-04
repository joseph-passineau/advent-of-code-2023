const fs = require('fs');
const readline = require('readline');
const { GamesValidator } = require('./games-validator');
const { GameRecord } = require('./game-record');

const gamesValidator = new GamesValidator(12, 13, 14);

const lineReader = readline.createInterface({
    input: fs.createReadStream('input.txt'),
    crlfDelay: Infinity
});

lineReader.on('line', (line) => {
    const gameRecord = new GameRecord(line);
    gamesValidator.addGameRecord(gameRecord);
});

lineReader.on('close', () => {
    const validGameRecords = gamesValidator.getValidGameRecords();
    const sumOfValidGameRecords = validGameRecords.reduce((previousValue, currentValue) => {
        return previousValue + currentValue.Id;
    }, 0);

    console.log('Sum of the IDs of valid games:', sumOfValidGameRecords);
})
