
                // JavaScript code here to handle search input
        const searchInput = document.getElementById('search-input');
        const employeeCards = document.querySelectorAll('.card');

        function updateSearchResults() {
                const searchText = searchInput.value.toLowerCase();

                employeeCards.forEach(card => {
                const employeeName = card.querySelector('.card-title').textContent.toLowerCase();
        const employeeEmail = card.querySelector('.card-subtitle').textContent.toLowerCase();
        const employeeJobTitle = card.querySelector('.card-text').textContent.toLowerCase();

        if (employeeName.includes(searchText) || employeeEmail.includes(searchText) || employeeJobTitle.includes(searchText)) {
            card.style.display = 'block';
                } else {
            card.style.display = 'none';
                }
                });
                }

                searchInput.addEventListener('input', () => {
            updateSearchResults();
                });

        // Initial call to populate search results
        updateSearchResults();








