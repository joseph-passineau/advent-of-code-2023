const { GameSet } = require('./game-set');

class GameRecord {
    constructor(value) {
        const gameRecordSplit = value.split(':');
        const gameSets = gameRecordSplit[1].split(';');

        this.Id = Number(gameRecordSplit[0].substring(4, gameRecordSplit[0].length));
        this.Sets = [];

        for(const gameSet of gameSets) {
            this.Sets.push(new GameSet(gameSet));
        }
    }

    getMinimumRequiredBalls() {
        const result = {
            red: 0,
            green: 0,
            blue: 0
        }

        for(const gameSet of this.Sets) {
            if(result.red < gameSet.RedBalls) {
                result.red = gameSet.RedBalls;
            }
            if(result.green < gameSet.GreenBalls) {
                result.green = gameSet.GreenBalls;
            }
            if(result.blue < gameSet.BlueBalls) {
                result.blue = gameSet.BlueBalls;
            }
        }

        return result;
    }
}

module.exports = {
    GameRecord,
};