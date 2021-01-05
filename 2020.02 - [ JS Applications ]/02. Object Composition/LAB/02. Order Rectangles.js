function solve(data) {
    const template = {
        width: 0,
        height: 0,
        area: function () {
            return this.width * this.height;
        },
        compareTo: function (other) {
            return this.area() - other.area() === 0
                ? this.width - other.width
                : this.area() - other.area();
        }

    };

    return data.map(([width, height]) => Object.assign(Object.create(template), { width, height })).sort((b, a) => a.compareTo(b));
}

console.log(
    solve([[10, 5], [5, 12], [3, 20]])
);

// [{width:5, height:12, area:function(), compareTo:function(other)},
// {width:10, height:5, area:funciton(),compareTo:function(other)}]
