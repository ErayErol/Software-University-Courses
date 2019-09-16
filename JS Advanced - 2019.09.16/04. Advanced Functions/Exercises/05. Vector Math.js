let vectorMath = (function () {
    function add(vec1, vec2) {
        let [a1, b1] = vec1;
        let [a2, b2] = vec2;
        return [a1 + a2, b1 + b2];
    }

    function multiply(vec1, scalar) {
        let [a, b] = vec1;
        return [a * scalar, b * scalar];
    }

    function length(vec1) {
        let [a, b] = vec1;
        return Math.sqrt(a * a + b * b);
    }

    function dot(vec1, vec2) {
        let [a1, b1] = vec1;
        let [a2, b2] = vec2;
        return a1 * a2 + b1 * b2;
    }

    function cross(vec1, vec2) {
        let [a1, b1] = vec1;
        let [a2, b2] = vec2;
        return a1 * b2 - b1 * a2;
    }

    return {
        add,
        multiply,
        length,
        dot,
        cross
    };
})();

console.log(vectorMath.add([1, 1], [1, 0]));
console.log(vectorMath.multiply([3.5, -2], 2));
console.log(vectorMath.length([3, -4]));
console.log(vectorMath.dot([1, 0], [0, -1]));
console.log(vectorMath.cross([3, 7], [1, 0]));

// testing in Judge => submit only the IIFE func