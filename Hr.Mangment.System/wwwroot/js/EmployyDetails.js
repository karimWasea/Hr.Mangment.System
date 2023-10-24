

$(document).ready(function () {
            var idField = $("#idField");
    var editProfileBtn = $(".edit-profile");

    idField.hide();

    editProfileBtn.click(function () {
        idField.toggle();
            });

    editProfileBtn.click(function (event) {
                var confirmMsg = "Are you sure you want to edit the profile?";
    if (!confirm(confirmMsg)) {
        event.preventDefault();
                }
            });
        });



