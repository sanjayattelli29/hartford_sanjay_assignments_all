document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById('enquiryForm');
    const successMessage = document.getElementById('success-message');

    const fullName = document.getElementById('fullName');
    const email = document.getElementById('email');
    const mobile = document.getElementById('mobile');
    const requestType = document.getElementById('requestType');
    const policyType = document.getElementById('policyType');
    const message = document.getElementById('message');
    const ratingInputs = document.getElementsByName('rating');

    form.addEventListener('submit', (e) => {
        e.preventDefault();

        let isValid = true;
        hideAllErrors();
        successMessage.classList.add('hidden');

        if (fullName.value.trim() === '') {
            showError(fullName, 'Please enter your full name.');
            isValid = false;
        }

        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (email.value.trim() === '') {
            showError(email, 'Please enter your email address.');
            isValid = false;
        } else if (!emailRegex.test(email.value.trim())) {
            showError(email, 'Please enter a valid email address.');
            isValid = false;
        }

        const mobileValue = mobile.value.trim();
        const mobileRegex = /^\d{10}$/;
        if (!mobileRegex.test(mobileValue)) {
            showError(mobile, 'Mobile number must be exactly 10 digits.');
            isValid = false;
        }

        if (requestType.value === '') {
            showError(requestType, 'Please select a request type.');
            isValid = false;
        }

        if (policyType.value === '') {
            showError(policyType, 'Please select a policy type.');
            isValid = false;
        }

        if (message.value.trim().length < 10) {
            showError(message, 'Message must be at least 10 characters long.');
            isValid = false;
        }

        let ratingSelected = false;
        for (const radio of ratingInputs) {
            if (radio.checked) {
                ratingSelected = true;
                break;
            }
        }
        if (!ratingSelected) {
            const ratingError = document.getElementById('rating-error');
            ratingError.textContent = 'Please select a rating.';
            ratingError.classList.remove('hidden');
            isValid = false;
        }

        if (isValid) {
            successMessage.classList.remove('hidden');

            form.reset();

            setTimeout(() => {
                successMessage.classList.add('hidden');
            }, 5000);
        }
    });

    function showError(inputElement, msg) {
        const errorElement = inputElement.nextElementSibling;
        if (errorElement && errorElement.classList.contains('error-message')) {
            errorElement.textContent = msg;
            errorElement.classList.remove('hidden');
        }
        inputElement.classList.add('border-red-500');
        inputElement.classList.remove('border-gray-300');
    }

    function hideAllErrors() {
        const errorMessages = document.querySelectorAll('.error-message');
        errorMessages.forEach(el => el.classList.add('hidden'));

        const inputs = document.querySelectorAll('input, select, textarea');
        inputs.forEach(input => {
            input.classList.remove('border-red-500');
            input.classList.add('border-gray-300');
        });
    }
});
