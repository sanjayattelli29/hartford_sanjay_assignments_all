let produts = [];

function getproducts() {
    fetch("https://dummyjson.com/products?limit=5")
    .then(res => res.json)
    .then(data => {
        produts = data.products;
        displayProducts();
    })
    .catch(err => console.error(err))
}

