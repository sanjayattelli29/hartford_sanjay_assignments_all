function calculatePremium(age, policyType, coverage) {
    let basePremium = 0;

    switch (policyType) {
        case 'Health Insurance':
            basePremium = 3000;
            break;
        case 'Life Insurance':
            basePremium = 5000;
            break;
        case 'Vehicle Insurance':
            basePremium = 2000;
            break;
        default:
            basePremium = 0;
    }

    if (age > 45) {
        basePremium = basePremium * 1.20;
    }

    const coverageInLakhs = coverage / 100000;
    const additionalPremium = coverageInLakhs * 500;

    return Math.floor(basePremium + additionalPremium);
}

const insurancePlans = [
    {
        id: 1,
        name: 'Health Insurance',
        basePremium: 3000,
        coverage: 'Up to ₹50L',
        icon: 'pulse-outline',
        color: 'text-red-500'
    },
    {
        id: 2,
        name: 'Life Insurance',
        basePremium: 5000,
        coverage: 'Up to ₹1Cr',
        icon: 'heart-outline',
        color: 'text-pink-500'
    },
    {
        id: 3,
        name: 'Vehicle Insurance',
        basePremium: 2000,
        coverage: 'Up to ₹20L',
        icon: 'car-sport-outline',
        color: 'text-brand-light'
    }
];

const customers = [
    { id: 1, name: 'Alice Johnson', age: 32, email: 'alice@example.com', policyType: 'Health Insurance', coverage: 500000, premium: 5500 },
    { id: 2, name: 'Bob Smith', age: 50, email: 'bob@example.com', policyType: 'Life Insurance', coverage: 1000000, premium: 11000 },
];
