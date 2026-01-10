const number = 10;
console.log("Initial:", number);

number = 20;
console.log("Updated:", number);

const multiplier = {
    factor: 2,
    numbers: [1, 2, 3],
    multiply: function () {
        return this.numbers.map(function (num) {
            return num * this.factor;
        });
    }
};

console.log(multiplier.multiply());

const numbers1 = [1, 2, 3, 4, 5, 6];

const evens = numbers1.filter(num => {
    num % 2 === 0;
});

console.log("Evens:", evens);

const prices = [100, 50, 300, 20];
const sortedPrices = prices.sort((a, b) => a - b);

console.log("Original Prices:", prices);
console.log("Sorted Prices:", sortedPrices);

const data = [10, 20, 30];

const total = data.reduce((acc, curr) => {
    acc + curr;
}, 0);

console.log("Total:", total);
