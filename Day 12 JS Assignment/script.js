let policies = [];
let currentFilter = 'all';

const policyData = [
    { id: 1, name: 'Health Plus', type: 'Health', premium: 12000, duration: 1, status: 'active', original: 12000 },
    { id: 2, name: 'Life Guard', type: 'Life', premium: 15000, duration: 20, status: 'active', original: 15000 },
    { id: 3, name: 'Vehicle Safe', type: 'Vehicle', premium: 8000, duration: 1, status: 'inactive', original: 8000 },
    { id: 4, name: 'Health Pro', type: 'Health', premium: 18000, duration: 2, status: 'active', original: 18000 },
    { id: 5, name: 'Family Life', type: 'Life', premium: 25000, duration: 30, status: 'active', original: 25000 },
    { id: 6, name: 'Car Protect', type: 'Vehicle', premium: 7500, duration: 1, status: 'active', original: 7500 }
];

function fetchPoliciesAPI() {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            if (policyData) {
                resolve(policyData);
            } else {
                reject('API Error');
            }
        }, 500);
    });
}

async function loadPolicies() {
    try {
        policies = await fetchPoliciesAPI();
        alert('Policies loaded successfully!');
        displayPolicies();
    } catch (error) {
        alert('Error loading policies: ' + error);
    }
}

function displayPolicies() {
    let container = document.getElementById('policies');
    let filtered = policies;
    
    if (currentFilter != 'all') {
        filtered = policies.filter(p => p.type == currentFilter);
    }
    
    if (filtered.length == 0) {
        container.innerHTML = '<p>No policies found</p>';
        return;
    }
    
    let html = '';
    for (let i = 0; i < filtered.length; i++) {
        let p = filtered[i];
        let statusClass = p.status == 'active' ? 'active-status' : 'inactive-status';
        let priceDisplay = '';
        
        if (p.premium != p.original) {
            priceDisplay = '<span class="original-price">Rs.' + p.original + '</span> <span class="discount-price">Rs.' + p.premium + '</span>';
        } else {
            priceDisplay = 'Rs.' + p.premium;
        }
        
        html += '<div class="policy">';
        html += '<h3>' + p.name + '</h3>';
        html += '<span class="status ' + statusClass + '">' + p.status + '</span>';
        html += '<p><b>Type:</b> ' + p.type + '</p>';
        html += '<p><b>Premium:</b> ' + priceDisplay + '</p>';
        html += '<p><b>Duration:</b> ' + p.duration + ' years</p>';
        html += '<button onclick="approvePolicy(' + p.id + ')">Approve</button>';
        html += '<button onclick="buyPolicy(' + p.id + ')">Buy</button>';
        html += '</div>';
    }
    container.innerHTML = html;
}

function filterPolicies(type) {
    currentFilter = type;
    
    let buttons = document.querySelectorAll('.filter-btn');
    buttons.forEach(btn => {
        btn.classList.remove('active');
    });
    
    event.target.classList.add('active');
    displayPolicies();
}

function calculateTotal() {
    try {
        let activePolicies = policies.filter(p => p.status == 'active');
        
        if (activePolicies.length == 0) {
            alert('No active policies found!');
            return;
        }
        
        let total = activePolicies.reduce((sum, p) => sum + p.premium, 0);
        alert('Total Premium of Active Policies: Rs.' + total);
    } catch (error) {
        alert('Error calculating total: ' + error);
    }
}

function applyDiscount() {
    try {
        let updated = policies.map(p => {
            if (p.premium > 10000) {
                let newPremium = p.premium - (p.premium * 0.10);
                return { ...p, premium: Math.round(newPremium) };
            }
            return p;
        });
        
        policies = updated;
        displayPolicies();
        alert('10% discount applied to policies above Rs.10,000!');
    } catch (error) {
        alert('Error applying discount: ' + error);
    }
}

function approvePolicy(id) {
    try {
        let policy = policies.find(p => p.id == id);
        
        if (!policy) {
            alert('Invalid policy ID');
            return;
        }
        
        if (confirm('Approve policy: ' + policy.name + '?')) {
            setTimeout(function() {
                policy.status = 'active';
                displayPolicies();
                alert('Policy approved: ' + policy.name);
            }, 2000);
            
            alert('Processing approval... Please wait 2 seconds');
        }
    } catch (error) {
        alert('Error approving policy: ' + error);
    }
}

function buyPolicy(id) {
    try {
        let policy = policies.find(p => p.id == id);
        
        if (!policy) {
            alert('Invalid policy ID');
            return;
        }
        
        let purchasePromise = new Promise((resolve, reject) => {
            setTimeout(() => {
                if (policy.premium > 0) {
                    resolve({ success: true, policyName: policy.name, amount: policy.premium });
                } else {
                    reject('Premium calculation failed');
                }
            }, 2000);
        });
        
        alert('Processing purchase... Please wait');
        
        purchasePromise.then(result => {
            policy.status = 'active';
            displayPolicies();
            alert('Policy purchased successfully!\nPolicy: ' + result.policyName + '\nAmount: Rs.' + result.amount);
        }).catch(error => {
            alert('Purchase failed: ' + error);
        });
        
    } catch (error) {
        alert('Error purchasing policy: ' + error);
    }
}
