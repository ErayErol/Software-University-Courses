function vectorMath() {
    let obj = {};
    let sum;

    function add(x, y) {
        sum[0] = x[0] + y[0];
        sum[1] = x[1] + y[1];
    }

    obj.add = add;
}