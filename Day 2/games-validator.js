class GamesValidator {
    constructor(maxRed, maxGreen, maxBlue) {
        this.GameRecords = [];
        this.MaxRed = maxRed;
        this.MaxGreen = maxGreen;
        this.MaxBlue = maxBlue;
    }

    addGameRecord(gameRecord) {
        this.GameRecords.push(gameRecord);
    }

    getValidGameRecords() {
        return this.GameRecords.filter(r => 
            r.Sets.every(s => 
                s.isValid(this.MaxRed, this.MaxGreen, this.MaxBlue)
            )
        );
    }
}

module.exports = {
    GamesValidator,
};