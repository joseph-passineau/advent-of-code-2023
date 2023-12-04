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
}

module.exports = {
    GameRecord,
};