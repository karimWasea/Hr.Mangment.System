document.addEventListener("DOMContentLoaded", function () {
    var saveForm = document.getElementById("saveform");

    saveForm.addEventListener("submit", function (event) {
        event.preventDefault();

        Swal.fire({
            title: "Are you sure?",
            text: "You are about to update the SalaryTransaction information.",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes, update it!",
            cancelButtonText: "No, cancel",
        }).then((result) => {
            if (result.isConfirmed) {
                // You can also add additional form validation here
                saveForm.submit();
            }
        });
    });
});