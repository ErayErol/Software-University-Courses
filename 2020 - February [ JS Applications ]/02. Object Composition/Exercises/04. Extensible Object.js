function solve(input) {
    let obj = {
        extend: function (template) {
            for (const key in template) {
                if (typeof template[key] === 'function') {
                    obj.__proto__[key] = template[key];
                }
                obj[key] = template[key];
            }
        }
    };

    obj.extend(input);
    return obj;
}

console.log(solve({
    fullName: function () {
        return `${this.firstName} ${this.lastName}`;
    },
    firstName: 'Eray',
    lastName: 'Erol',
}));