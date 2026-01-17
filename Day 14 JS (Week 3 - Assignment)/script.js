let accounts = []
let transactions = {}
let currentAccountId = null

const accountsGrid = document.getElementById('accountsGrid')
const loader = document.getElementById('loader')
const errorMsg = document.getElementById('errorMessage')
const searchInput = document.getElementById('searchInput')
const branchFilter = document.getElementById('branchFilter')
const sortBtn = document.getElementById('sortBtn')
const totalBalanceDisplay = document.getElementById('totalBalanceDisplay')
const createAccountForm = document.getElementById('createAccountForm')

const transactionModal = document.getElementById('transactionModal')
const historyModal = document.getElementById('historyModal')
const closeModal = document.querySelector('.close-modal')
const closeHistoryModal = document.querySelector('.close-modal-history')

const modalAccountName = document.getElementById('modalAccountName')
const transactionAmount = document.getElementById('transactionAmount')
const depositBtn = document.getElementById('depositBtn')
const withdrawBtn = document.getElementById('withdrawBtn')
async function init() {
    loadFromLocalStorage()

    if (accounts.length === 0) {
        await fetchAccounts()
    } else {
        renderAccounts(accounts)
        populateBranchFilter()
        updateTotalBalance()
    }
}

async function fetchAccounts() {
    showLoader(true)
    try {
        const response = await fetch('https://jsonplaceholder.typicode.com/users')
        if (!response.ok) throw new Error('Failed to fetch data')

        const data = await response.json()

        accounts = data.map(user => ({
            id: user.id,
            name: user.name,
            email: user.email,
            branch: user.address.city,
            balance: Math.floor(Math.random() * 40001) + 10000
        }))

        saveToLocalStorage()
        renderAccounts(accounts)
        populateBranchFilter()
        updateTotalBalance()

    } catch (error) {
        showError('Error loading accounts. Please check your connection.')
    } finally {
        showLoader(false)
    }
}

function renderAccounts(data) {
    accountsGrid.innerHTML = ''

    if (data.length === 0) {
        accountsGrid.innerHTML = '<p>No accounts found.</p>'
        return
    }

    data.forEach(acc => {
        const card = document.createElement('div')
        card.className = `account-card ${acc.balance < 5000 ? 'low-balance' : ''}`

        card.innerHTML = `
            <div class="account-header">
                <h3>${acc.name}</h3>
                <span class="account-id">ID: ${acc.id}</span>
            </div>
            <div class="account-details">
                <p><strong>Email:</strong> ${acc.email}</p>
                <p><strong>Branch:</strong> ${acc.branch}</p>
                <p><strong>Balance:</strong> ₹ <span class="balance-highlight">${acc.balance}</span></p>
                ${acc.balance < 5000 ? '<p style="color:red; font-size: 0.8rem;">⚠️ Low Balance (Penalty Applied)</p>' : ''}
            </div>
            <div class="account-actions">
                <button class="btn btn-sm btn-outline" onclick="openTransactionModal(${acc.id})">Transact</button>
                <button class="btn btn-sm btn-outline" onclick="viewHistory(${acc.id})">History</button>
                <button class="btn btn-sm btn-outline delete-btn" onclick="deleteAccount(${acc.id})">Delete</button>
            </div>
        `
        accountsGrid.appendChild(card)
    })
}

function filterAccounts() {
    const searchTerm = searchInput.value.toLowerCase()
    const branchValue = branchFilter.value

    const filtered = accounts.filter(acc => {
        const matchesName = acc.name.toLowerCase().includes(searchTerm)
        const matchesBranch = branchValue ? acc.branch === branchValue : true
        return matchesName && matchesBranch
    })

    renderAccounts(filtered)
    updateTotalBalance(filtered)
}

searchInput.addEventListener('input', filterAccounts)
branchFilter.addEventListener('change', filterAccounts)

function populateBranchFilter() {
    const branches = [...new Set(accounts.map(acc => acc.branch))]
    branchFilter.innerHTML = '<option value="">All Branches</option>'
    branches.forEach(branch => {
        const option = document.createElement('option')
        option.value = branch
        option.innerText = branch
        branchFilter.appendChild(option)
    })
}

sortBtn.addEventListener('click', () => {
    accounts.sort((a, b) => b.balance - a.balance)
    renderAccounts(accounts)
    filterAccounts()
    filterAccounts()
})

function updateTotalBalance(subset = accounts) {
    const total = subset.reduce((sum, acc) => sum + acc.balance, 0)
    totalBalanceDisplay.innerText = `₹ ${total.toLocaleString()}`
}

createAccountForm.addEventListener('submit', async (e) => {
    e.preventDefault()

    showLoader(true)

    const newName = document.getElementById('newName').value
    const newEmail = document.getElementById('newEmail').value
    const newBranch = document.getElementById('newBranch').value

    const newAccount = {
        id: Date.now(),
        name: newName,
        email: newEmail,
        branch: newBranch,
        balance: 10000
    }

    try {
        await new Promise(resolve => setTimeout(resolve, 500))

        accounts.push(newAccount)
        saveToLocalStorage()

        createAccountForm.reset()
        renderAccounts(accounts)
        populateBranchFilter()
        updateTotalBalance()

        alert('Account Created Successfully!')

    } catch (err) {
        showError('Failed to create account')
    } finally {
        showLoader(false)
    }
})

window.deleteAccount = async (id) => {
    if (!confirm('Are you sure you want to delete this account?')) return

    showLoader(true)
    try {
        await new Promise(resolve => setTimeout(resolve, 300))

        accounts = accounts.filter(acc => acc.id !== id)
        delete transactions[id]

        saveToLocalStorage()
        renderAccounts(accounts)
        updateTotalBalance()

    } catch (err) {
        showError('Failed to delete account')
    } finally {
        showLoader(false)
    }
}

window.openTransactionModal = (id) => {
    currentAccountId = id
    const acc = accounts.find(a => a.id === id)
    modalAccountName.innerText = `Account: ${acc.name} (Bal: ₹${acc.balance})`
    transactionAmount.value = ''
    transactionModal.classList.remove('hidden')
}

closeModal.addEventListener('click', () => {
    transactionModal.classList.add('hidden')
    currentAccountId = null
})

depositBtn.addEventListener('click', () => handleTransaction('deposit'))
withdrawBtn.addEventListener('click', () => handleTransaction('withdraw'))

function handleTransaction(type) {
    const amount = Number(transactionAmount.value)
    if (!amount || amount <= 0) {
        alert('Please enter a valid amount')
        return
    }

    const accountIndex = accounts.findIndex(a => a.id === currentAccountId)
    const account = accounts[accountIndex]

    if (type === 'withdraw') {
        if (account.balance < amount) {
            alert('Insufficient Funds!')
            return
        }

        account.balance -= amount

        if (account.balance < 5000) {
            account.balance -= 200
            alert('Warning: Balance below ₹5,000. Penalty of ₹200 applied.')
        }
    } else {
        account.balance += amount
    }

    addTransactionHistory(account.id, type, amount, account.balance)

    saveToLocalStorage()
    renderAccounts(accounts)
    updateTotalBalance()

    transactionModal.classList.add('hidden')
    alert('Transaction Successful')
}

function addTransactionHistory(id, type, amount, newBalance) {
    if (!transactions[id]) transactions[id] = []

    transactions[id].unshift({
        date: new Date().toLocaleString(),
        type: type,
        amount: amount,
        balanceAfter: newBalance
    })
}

window.viewHistory = (id) => {
    const acc = accounts.find(a => a.id === id)
    document.getElementById('historyAccountName').innerText = `History for: ${acc.name}`

    const list = document.getElementById('transactionList')
    list.innerHTML = ''

    const history = transactions[id] || []

    if (history.length === 0) {
        list.innerHTML = '<li>No transactions found.</li>'
    } else {
        history.forEach(t => {
            const li = document.createElement('li')
            li.innerHTML = `
                <div>
                    <span class="history-type ${t.type}">${t.type.toUpperCase()}</span> 
                    ₹${t.amount}
                </div>
                <div style="text-align:right">
                    <div>Bal: ₹${t.balanceAfter}</div>
                    <div class="history-date">${t.date}</div>
                </div>
            `
            list.appendChild(li)
        })
    }

    historyModal.classList.remove('hidden')
}

closeHistoryModal.addEventListener('click', () => {
    historyModal.classList.add('hidden')
})

function showLoader(show) {
    if (show) loader.classList.remove('hidden')
    else loader.classList.add('hidden')
}

function showError(msg) {
    errorMsg.innerText = msg
    errorMsg.classList.remove('hidden')
    setTimeout(() => errorMsg.classList.add('hidden'), 3000)
}

function saveToLocalStorage() {
    localStorage.setItem('bankData', JSON.stringify(accounts))
    localStorage.setItem('transactionData', JSON.stringify(transactions))
}

function loadFromLocalStorage() {
    const data = localStorage.getItem('bankData')
    const trans = localStorage.getItem('transactionData')

    if (data) accounts = JSON.parse(data)
    if (trans) transactions = JSON.parse(trans)
}

init()
