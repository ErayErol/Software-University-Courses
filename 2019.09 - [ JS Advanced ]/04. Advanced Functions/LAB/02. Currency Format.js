function solve(money) {
    function getDollarFormatter(formatter) {
        function dollarFormatter(value) {
            return formatter(',', '$', true, value);
        }

        return dollarFormatter;
    }

    return getDollarFormatter(money);
}