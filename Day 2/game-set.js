class GameSet {
    constructor(value) {
        this.RedBalls = 0;
        this.GreenBalls = 0;
        this.BlueBalls = 0;

        const cubes = value.split(',');

        for(const cube of cubes) {

            const cubeSplit = cube.trim().split(" ");
            const quantity = Number(cubeSplit[0]);
            const colorName = cubeSplit[1].trim();

            switch(colorName) {
                case 'red':
                    this.RedBalls = quantity;
                    break;
                case 'green':
                    this.GreenBalls = quantity;
                    break;
                case 'blue':
                    this.BlueBalls = quantity;
                    break;
            }
        }
    }

    isValid(maxRed, maxGreen, maxBlue) {
        return this.RedBalls <= maxRed && this.GreenBalls <= maxGreen && this.BlueBalls <= maxBlue;
    }
}

module.exports = {
    GameSet,
};