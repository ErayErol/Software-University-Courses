const Extensible = (function () {
    let id = 0;

    return class Extensible {
        constructor() {
            this.id = id++;
        }

        extend(template) {
            Object.entries(template)
                .forEach(([key, value]) => {

                    (typeof value === 'function')
                        ? Object.getPrototypeOf(this)[key] = value
                        : this[key] = value;

                });
        }
    };
}());

let obj1 = new Extensible();
let obj2 = new Extensible();
let obj3 = new Extensible();
console.log(obj1.id);
console.log(obj2.id);
console.log(obj3.id);

obj1.extend({
    extensionMethod: function () { },
    extensionProperty: 'someString'
});

console.log(Object.getPrototypeOf(obj1).extensionMethod);

// submit only IIFE for judge