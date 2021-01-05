function subSum(arr, startIndex, endIndex) {
    if (Array.isArray(arr) == false || arr.find(x => isNaN(Number(x)))) {
        return NaN;
    }

    if (arr.length === 0) {
        return 0;
    }

    if (startIndex < 0) {
        startIndex = 0;
    }

    return arr.slice(startIndex, endIndex + 1).reduce((a, b) => a + b);
}