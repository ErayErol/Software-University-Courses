class Stringer {
    constructor(innerString, innerLength) {
        this.innerString = innerString;
        this.innerLength = innerLength;
    }

    increase(length) {
        this.innerLength += length;
    }

    decrease(length) {
        this.innerLength -= length;
        if (this.innerLength < 0) {
            this.innerLength = 0;
        }
    }

    toString() {
        let threeDots = '...';
        if (this.innerString.length > this.innerLength) {
            if (this.innerLength === 0) {
                return threeDots;
            } else {
                return this.innerString.substring(0, this.innerLength) + threeDots;
            }
        }

        return this.innerString;
    }
}