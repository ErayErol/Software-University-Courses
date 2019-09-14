function sortArray(numeric, argument) {
    if (argument === 'asc') {
        return numeric.sort((a, b) => a - b);
    } else if (argument === 'desc') {
        return numeric.sort((a, b) => b - a);
    }
}

sortArray([14, 7, 17, 6, 8], 'asc');

sortArray([14, 7, 17, 6, 8], 'desc');