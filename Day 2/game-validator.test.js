const { GameRecord } = require('./game-record');
const { GamesValidator } = require('./games-validator');

test.each([
    ['Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green', true],
    ['Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue', true],
    ['Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red', false],
    ['Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red', false],
    ['Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green', true],
])('game set %s with max 12 red balls, 13 green balls and 14 blue balls is valid: %s', (line, expectedIsValid) => {
    const gamesValidator = new GamesValidator(12, 13, 14);
    gamesValidator.addGameRecord(new GameRecord(line));
    expect(gamesValidator.getValidGameRecords().length == 1).toBe(expectedIsValid);
})