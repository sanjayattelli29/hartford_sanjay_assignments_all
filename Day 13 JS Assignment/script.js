let products = [];

function getProducts() {
    fetch("https://dummyjson.com/products?limit=5")
        .then(res => res.json())
        .then(data => {
            products = data.products;
            displayProducts();
        })
        .catch(err => console.error(err));
}

function displayProducts() {
    const tbody = document.getElementById("productBody");
    tbody.innerHTML = "";

    products.forEach(p => {
        const row = document.createElement("tr");
        row.innerHTML = `
            <td>${p.id}</td>
            <td>${p.title}</td>
            <td>${p.price}</td>
        `;
        tbody.appendChild(row);
    });
}

function addProduct(e) {
    e.preventDefault();

    const title = document.getElementById("title").value;
    const price = document.getElementById("price").value;

    fetch("https://dummyjson.com/products/add", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ title, price })
    })
    .then(res => res.json())
    .then(newProduct => {
        products.unshift(newProduct);
        products = products.slice(0, 5);
        displayProducts();
        e.target.reset();
    })
    .catch(err => console.error(err));
}


function updateProduct(e) {
    e.preventDefault();

    const id = document.getElementById("updateId").value;
    const price = document.getElementById("updatePrice").value;

    fetch(`https://dummyjson.com/products/${id}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ price })
    })
    .then(res => res.json())
    .then(updated => {
        const index = products.findIndex(p => p.id == id);
        if (index !== -1) {
            products[index].price = updated.price;
            displayProducts();
        }
        e.target.reset();
    })
    .catch(err => console.error(err));
}

function deleteProduct(e) {
    e.preventDefault();

    const id = document.getElementById("deleteId").value;

    fetch(`https://dummyjson.com/products/${id}`, {
        method: "DELETE"
    })
    .then(res => res.json())
    .then(() => {
        products = products.filter(p => p.id != id);
        displayProducts();
        e.target.reset();
    })
    .catch(err => console.error(err));
}
