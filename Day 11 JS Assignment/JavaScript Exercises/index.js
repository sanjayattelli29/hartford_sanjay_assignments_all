// task 1 - change title using id
const pageTitle = document.getElementById('pageTitle');
pageTitle.textContent = "Customer Insurance Overview";
console.log("Title updated");


// task 2 - get all li tags and add border
const allListItems = document.getElementsByTagName('li');
for (let i = 0; i < allListItems.length; i++) {
  allListItems[i].style.border = "2px solid #333";
}
console.log("Customer list count");


// task 3 - select by class name and style them
const policyElements = document.getElementsByClassName('policy');
for (let i = 0; i < policyElements.length; i++) {
  policyElements[i].classList.add('highlight');
  policyElements[i].style.color = "blue";
}
console.log("Policies highlighted");


// task 4 - css selectors for first, all, and last customer
const firstCustomer = document.querySelector('.customer');
console.log("First customer shown");

const allCustomers = document.querySelectorAll('.customer');
console.log("Total customers");

const lastCustomer = allCustomers[allCustomers.length - 1];
lastCustomer.classList.add('active');
console.log("Last customer active");


// task 5 - html object collections for forms, images, links
const formsCount = document.forms.length;
console.log("Forms count");

const imagesCount = document.images.length;
console.log("Images count");

const allLinks = document.links;
for (let i = 0; i < allLinks.length; i++) {
  allLinks[i].textContent = "More Info";
}
console.log("Links renamed");


// task 6 - add new customer and check what updates
const customerList = document.getElementById('customerList');
const newCustomer = document.createElement('li');
newCustomer.className = 'customer';
newCustomer.textContent = "Priya – Health";
customerList.appendChild(newCustomer);
console.log("New customer added");
console.log("Customer list updated");
console.log("Static list unchanged");


// task 7 - select text inputs by attribute
const textInputs = document.querySelectorAll('input[type="text"]');
textInputs.forEach(input => {
  input.style.backgroundColor = "yellow";
  input.placeholder = "Enter Full Name";
});
console.log("Inputs styled");


// task 8 - select elements with multiple classes
const priorityCustomers = document.querySelectorAll('.customer.active');
priorityCustomers.forEach(customer => {
  customer.style.color = "darkgreen";
  customer.textContent += " (Priority Customer)";
});
console.log("Priority customers marked");


// task 9 - descendant vs child selector
const descendantLi = document.querySelectorAll('#customerList li');
console.log("All list items");

const childLi = document.querySelectorAll('#customerList > li');
console.log("Direct list items");
console.log("Selector difference");


// task 10 - even and odd styling with nth-child
const evenCustomers = document.querySelectorAll('#customerList li:nth-child(even)');
evenCustomers.forEach(customer => {
  customer.style.backgroundColor = "lightgray";
});

const oddCustomers = document.querySelectorAll('#customerList li:nth-child(odd)');
oddCustomers.forEach(customer => {
  customer.style.backgroundColor = "lightblue";
});
console.log("Even odd styled");


// task 11 - form elements collection
const enquiryForm = document.forms['enquiryForm'];
console.log("Form accessed");

const formElements = enquiryForm.elements;
console.log("Form fields listed");

for (let i = 0; i < formElements.length; i++) {
  if (formElements[i].name) {
    console.log(formElements[i].name);
  }
}

const submitButton = enquiryForm.querySelector('button[type="submit"]');
submitButton.disabled = true;
console.log("Submit disabled");


// task 12 - nodelist vs htmlcollection difference
console.log("Policy count before");

const policiesByClass = document.getElementsByClassName('policy');
console.log("Live collection count");

const policiesByQuery = document.querySelectorAll('.policy');
console.log("Static collection count");

const newPolicy = document.createElement('p');
newPolicy.className = 'policy';
newPolicy.textContent = "Term Insurance";
document.body.insertBefore(newPolicy, document.querySelector('form'));

console.log("Policy added");
console.log("Live list updated");
console.log("Static list same");


// task 13 - filter by text content
const customersForFiltering = document.querySelectorAll('.customer');
customersForFiltering.forEach(customer => {
  if (customer.textContent.includes('Life')) {
    customer.style.backgroundColor = "#ffffcc";
    customer.style.fontWeight = "bold";
  }
  if (customer.textContent.includes('Vehicle')) {
    customer.style.display = "none";
  }
});
console.log("Life highlighted");
console.log("Vehicle hidden");


// task 14 - closest parent traversal on click
const allCustomerItems = document.querySelectorAll('.customer');
allCustomerItems.forEach(customer => {
  customer.addEventListener('click', function() {
    const nearestUl = this.closest('ul');
    nearestUl.style.border = "3px solid red";
    console.log("UL highlighted");
  });
});
console.log("Click event added");


// task 15 - complex selector with not
const policiesExceptFirst = document.querySelectorAll('.policy:not(:first-child)');
policiesExceptFirst.forEach(policy => {
  policy.style.fontStyle = "italic";
  policy.textContent = "✔ " + policy.textContent;
});
console.log("Policies styled");
