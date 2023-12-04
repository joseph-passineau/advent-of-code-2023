const { GameSet } = require('./game-set');

test.each([
    ['3 blue, 4 red', 4, 0, 3],
    ['1 red, 2 green, 6 blue', 1, 2, 6],
    ['2 green', 0, 2, 0],
])('game set %s should have %i red balls, %i green balls and %i blue balls', (line, expectedRedBalls, expectedGreenBalls, expectedBlueBalls) => {
    const gameSet = new GameSet(line);
    expect(gameSet.RedBalls).toBe(expectedRedBalls);
    expect(gameSet.GreenBalls).toBe(expectedGreenBalls);
    expect(gameSet.BlueBalls).toBe(expectedBlueBalls);
})