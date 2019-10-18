'use strict';
function foo(a, b, c) {
    console.log(this, a, b, c);
}

function HRFD(fn, p1, p2) {
    return fn.bind('Im THIS', p1, p2);
}

const myFoo = HRFD(foo, 1, 2);

myFoo(3);
foo(3);