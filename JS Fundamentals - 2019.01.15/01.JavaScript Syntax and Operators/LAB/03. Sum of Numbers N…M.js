function solve(n, m) {

    n = Number(n);
    m = Number(m);
    let sum = 0;

    while (n <= m) sum += n++;
    return sum;
}