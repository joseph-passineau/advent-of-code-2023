class GamesStatistics {
    constructor() {
        this.GameRecords = [];
    }

    addGameRecord(gameRecord) {
        this.GameRecords.push(gameRecord);
    }

    calculatePowerOfFewestNeededCubes() {
        return this.GameRecords.reduce((previousValue, currentValue) => {
            const minimumRequireBalls = currentValue.getMinimumRequiredBalls();
            return previousValue + (minimumRequireBalls.red * minimumRequireBalls.green * minimumRequireBalls.blue);
        }, 0);
    }
}

module.exports = {
    GamesStatistics,
};