
    // Get the search input element
        const searchInput = document.getElementById('search-input');

        // Get the patient rows
        const patientRows = document.querySelectorAll('.patient');

        // Function to update the search results
        function updateSearchResults() {
        const searchText = searchInput.value.toLowerCase();

        patientRows.forEach(patientRow => {
            const patientText = patientRow.textContent.toLowerCase();
        if (patientText.includes(searchText)) {
            patientRow.style.display = 'table-row';
            } else {
            patientRow.style.display = 'none';
            }
        });
    }

        // Add an event listener to the search input to listen for input changes
        searchInput.addEventListener('input', function () {
            updateSearchResults();
    });

        // Initial call to populate search results
        updateSearchResults();
