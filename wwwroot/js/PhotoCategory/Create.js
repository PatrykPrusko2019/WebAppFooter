$(document).ready(function () {
    $("#createPhotoCategoryModal form").submit(function (event) {
        event.preventDefault();

        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (_data) {
                location.reload(true)
                toastr["success"]("Created Photo/Category")
            },
            error: function () {
                toastr["error"]("Something went wrong");
            }
        });
    });
});