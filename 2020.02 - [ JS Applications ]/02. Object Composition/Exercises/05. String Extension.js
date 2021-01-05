(function () {
    String.prototype.ensureStart = function (str) {
        if (this.startsWith(str)) {
            return this.toString();
        }
        return `${str}${this}`;
    };

    String.prototype.ensureEnd = function (str) {
        if (this.endsWith(str)) {
            return this.toString();
        }
        return `${this}${str}`;
    };

    String.prototype.isEmpty = function () {
        return this.toString() === '';
    };

    String.prototype.truncate = function (n) {
        if (n < 4 && n >= 0) {
            return '.'.repeat(n);
        } else if (n >= this.length) {
            return this.toString();
        } else if (n < this.length) {
            let indexOf = this.substr(0, n - 2).lastIndexOf(' ');

            if (indexOf > 0) {
                return this.substr(0, indexOf) + '...';
            } else {
                return this.substr(0, n - 3) + '...';
            }
        }
    };

    String.format = function (string, ...params) {
        return params
            .reduce((prev, curr, i) => {
                prev = prev.replace(`{${i}}`, curr);
                return prev;
            }, string);
    };
}());

let str = 'United is my favorite';

console.log(str.ensureStart('Manchester '));
console.log(str.ensureStart('Manchester '));

console.log(str.ensureEnd('favorite'));
console.log(str.ensureEnd(' team!'));

console.log(str.truncate(-7));
console.log(str.truncate(5));
console.log(str.truncate(9));
console.log(str.truncate(14));
console.log(str.truncate(25));


console.log(String.format('Manchester {0} is my {1} {2}!',
    'United', 'favorite', 'team'));

console.log(String.format('Manchester {0} is my {1} {2} {1}!',
    'United', 'favorite', 'team'));