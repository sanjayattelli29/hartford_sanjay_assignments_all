document.addEventListener('DOMContentLoaded', () => {

    let customerList = [...customers];

    const plansContainer = document.getElementById('plans-container');
    const tableBody = document.getElementById('customer-table-body');
    const customerForm = document.getElementById('customerForm');

    const statCustomers = document.getElementById('stat-customers');
    const statPolicies = document.getElementById('stat-policies');
    const statPremium = document.getElementById('stat-premium');

    const inputCoverage = document.getElementById('c-coverage');
    const displayCoverage = document.getElementById('coverage-val');

    const searchInput = document.getElementById('search-input');
    const filterPolicy = document.getElementById('filter-policy');

    renderPlans();
    updateDashboard();

    inputCoverage.addEventListener('input', (e) => {
        const val = parseInt(e.target.value).toLocaleString('en-IN');
        displayCoverage.textContent = `₹${val}`;
    });

    customerForm.addEventListener('submit', (e) => {
        e.preventDefault();

        const name = document.getElementById('c-name').value.trim();
        const email = document.getElementById('c-email').value.trim();
        const age = parseInt(document.getElementById('c-age').value);
        const policy = document.getElementById('c-policy').value;
        const coverage = parseInt(inputCoverage.value);

        let isValid = true;
        clearFormErrors();

        if (!name) { showFormError('c-name', 'Name is required'); isValid = false; }
        if (!email) { showFormError('c-email', 'Email is required'); isValid = false; }
        if (!age || age < 18) { showFormError('c-age', 'Valid age (18+) required'); isValid = false; }
        if (!policy) { showFormError('c-policy', 'Please select a policy'); isValid = false; }

        if (isValid) {
            const premium = calculatePremium(age, policy, coverage);

            const newCustomer = {
                id: Date.now(),
                name,
                email,
                age,
                policyType: policy,
                coverage,
                premium
            };

            customerList.push(newCustomer);

            updateDashboard();
            customerForm.reset();
            displayCoverage.textContent = '₹5,00,000';
            inputCoverage.value = 500000;
        }
    });

    searchInput.addEventListener('input', updateDashboard);
    filterPolicy.addEventListener('change', updateDashboard);


    function renderPlans() {
        plansContainer.innerHTML = insurancePlans.map(plan => `
            <div class="bg-white p-6 rounded-lg shadow-md plan-card border-t-4 border-brand-light">
                <div class="flex items-center justify-between mb-4">
                    <h4 class="text-xl font-bold text-gray-800">${plan.name}</h4>
                    <div class="text-3xl ${plan.color}"><ion-icon name="${plan.icon}"></ion-icon></div>
                </div>
                <p class="text-gray-600 mb-2">Base Premium: <span class="font-semibold">₹${plan.basePremium}</span>/yr</p>
                <p class="text-gray-600 mb-6">Coverage: ${plan.coverage}</p>
                <button class="w-full bg-gray-50 text-brand-dark font-bold py-2 rounded hover:bg-gray-100 transition border border-gray-200">
                    View Details
                </button>
            </div>
        `).join('');
    }

    function updateDashboard() {
        const searchTerm = searchInput.value.toLowerCase();
        const filterValue = filterPolicy.value;

        const filteredCustomers = customerList.filter(c => {
            const matchesName = c.name.toLowerCase().includes(searchTerm);
            const matchesPolicy = filterValue === 'all' || c.policyType === filterValue;
            return matchesName && matchesPolicy;
        });

        renderTable(filteredCustomers);

        updateStats(customerList);
    }

    function renderTable(data) {
        const tbody = document.getElementById('customer-table-body');
        const noResults = document.getElementById('no-results');

        if (data.length === 0) {
            tbody.innerHTML = '';
            noResults.classList.remove('hidden');
            return;
        }

        noResults.classList.add('hidden');
        tbody.innerHTML = data.map(customer => `
            <tr class="border-b transition hover:bg-gray-50">
                <td class="p-4 font-medium text-gray-800">${customer.name}</td>
                <td class="p-4">${customer.age}</td>
                <td class="p-4">
                    <span class="px-2 py-1 rounded-full text-xs font-semibold
                        ${getPolicyBadgeColor(customer.policyType)}">
                        ${customer.policyType}
                    </span>
                </td>
                <td class="p-4">₹${customer.coverage.toLocaleString('en-IN')}</td>
                <td class="p-4 font-bold text-brand-dark">₹${customer.premium.toLocaleString('en-IN')}</td>
                <td class="p-4 text-center">
                    <button class="text-red-500 hover:text-red-700 transition" onclick="deleteCustomer(${customer.id})">
                        <ion-icon name="trash-outline"></ion-icon>
                    </button>
                </td>
            </tr>
        `).join('');
    }

    function updateStats(data) {
        statCustomers.textContent = data.length;

        statPolicies.textContent = data.length;

        const totalPremium = data.reduce((sum, customer) => sum + customer.premium, 0);
        statPremium.textContent = `₹${totalPremium.toLocaleString('en-IN')}`;
    }

    function getPolicyBadgeColor(type) {
        if (type === 'Health Insurance') return 'bg-red-100 text-red-700';
        if (type === 'Life Insurance') return 'bg-pink-100 text-pink-700';
        if (type === 'Vehicle Insurance') return 'bg-blue-100 text-blue-700';
        return 'bg-gray-100 text-gray-700';
    }

    function showFormError(inputId, msg) {
        const input = document.getElementById(inputId);
        const errorP = input.nextElementSibling;
        input.classList.add('border-red-500');
        errorP.textContent = msg;
        errorP.classList.remove('hidden');
    }

    function clearFormErrors() {
        const inputs = document.querySelectorAll('#customerForm input, #customerForm select');
        inputs.forEach(i => {
            i.classList.remove('border-red-500');
            i.nextElementSibling.classList.add('hidden');
        });
    }

    window.deleteCustomer = (id) => {
        if (confirm('Are you sure you want to remove this customer?')) {
            customerList = customerList.filter(c => c.id !== id);
            updateDashboard();
        }
    };
});
