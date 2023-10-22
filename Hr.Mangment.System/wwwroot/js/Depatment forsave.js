    document.addEventListener("DOMContentLoaded", function () {
        // Initialize Select2 on all select elements
        $('select').select2();

    var saveForm = document.getElementById("saveform");
    var saveButton = document.getElementById("savedata");

    saveForm.addEventListener("submit", function (event) {
        event.preventDefault();

    Swal.fire({
        title: "Are you sure?",
    text: "You are about to update the department's information.",
    icon: "warning",
    showCancelButton: true,
    confirmButtonText: "Yes, update it!",
    cancelButtonText: "No, cancel",
                }).then((result) => {
                    if (result.isConfirmed) {
        // Submit the form if SweetAlert confirmation is accepted
        saveForm.submit();
                    }
                });
            });
        });
