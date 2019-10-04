function subSum(arr, sIndex, eIndex) {
    let sum = 0;

    if (sIndex < 0) {
        sIndex = 0;
    }

    if (eIndex > arr.length) {
        eIndex = arr.length - 1;
    }

    for (let i = sIndex; i <= eIndex; i++) {
        const element = (+arr[i]);
        sum += element;
    }

    console.log(sum);
}

subSum([10, 20, 30, 40, 50, 60], 3, 300);

subSum([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1);

subSum([10, 'twenty', 30, 40], 0, 2);

subSum([], 1, 2);

subSum('text', 0, 2);