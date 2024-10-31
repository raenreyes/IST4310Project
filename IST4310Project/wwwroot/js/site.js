
$(document).ready(function () {
    $('.holder').click(function () {
        alert("Logging Out...");
        window.location.href = "https://localhost:7093/"
    })

    $('#modal-launcher, #modal-close').click(function () {
        $('#modal-content, #modal-background').toggleClass('active');
    });
    $('#modal-user-create').click(function (e) {
        e.preventDefault(); //prevents the default action
        $.ajax({
            type: 'POST',
            url: "https://localhost:7093/home/newuser",
            content: "application/json; charset=utf-8",
            dataType: 'json',
            data: {
                firstName: $('#firstName').val(),
                lastName: $('#lastName').val(),
                password: $('#password').val(),
                email: $('#email').val(),
                gender: $('#gender').val(),
                height: $('#height').val(),
                dept: $('#dept').val(),
                major: $('#major').val(),
            },
            success: function (d) {
                $('#modal-close').click();
                alert(d.message);

            }
        })
    });

});
