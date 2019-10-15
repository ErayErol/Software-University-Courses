class List {
    constructor() {
        this.data = [];
        this.size = this.data.length;
    }

    add(number) {
        this.size++;
        this.data.push(number);
        this.data.sort((a, b) => a - b);
    }

    get(index) {
        return this.data[index];
    }

    remove(index) {
        if (index >= 0 && index < this.data.length) {
            this.size--;
            this.data.splice(index, 1);
        }
    }
}