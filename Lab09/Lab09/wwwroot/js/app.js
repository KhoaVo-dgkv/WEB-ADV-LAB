// API Configuration
const API_BASE_URL = 'https://localhost:7052/api'; // Change to http://localhost:5237/api if using HTTP

// Common utility functions
function showMessage(messageDivId, message, type) {
    const messageDiv = $(messageDivId);
    messageDiv.removeClass('alert-success alert-danger alert-warning alert-info');
    messageDiv.addClass(`alert alert-${type} alert-dismissible fade show`);
    messageDiv.html(`${message}<button type="button" class="btn-close" data-bs-dismiss="alert"></button>`);
    messageDiv.fadeIn();
    
    setTimeout(function() {
        messageDiv.fadeOut();
    }, 5000);
}

function escapeHtml(text) {
    const div = document.createElement('div');
    div.textContent = text;
    return div.innerHTML;
}

function formatCurrency(amount) {
    return new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD'
    }).format(amount);
}

