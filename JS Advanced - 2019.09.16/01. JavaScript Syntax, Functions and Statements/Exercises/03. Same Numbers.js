function solve(nums) {
    nums = nums.toString();
    const lastNum = nums[nums.length - 1];

    let result = 'true';
    let sum = 0;
    
    for (let i = 0; i < nums.length - 1; i++) {
        const element = nums[i];

        sum += Number(element);
        if (element !== nums[i + 1]) {
            result = 'false';
        }

        if (i + 1 === nums.length - 1) {
            sum += Number(lastNum);
            if (element !== lastNum) {
                result = 'false';
            }
        }
    }

    console.log(result);
    console.log(sum);
}

solve(2222222);

solve(1234);