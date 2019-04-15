function solve(first, second, third) {

    let firstLength = first.length;
    let secondLength = second.length;
    let thirdtLength = third.length;

    let sumLength = firstLength + secondLength + thirdtLength;
    let sumAverage = Math.floor(sumLength / 3);

    console.log(sumLength);
    console.log(sumAverage);
}