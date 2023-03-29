$(function () {
    $("#RegistrationModal input[name = 'Email']").blur(function () {
        var email = $("#RegistrationModal input[name = 'Email']").val();

        var url = "UserAuth/UserNameExists?userName=" + email;

        $.ajax({
            type: "GET",
            url: url,
            success: function (data) {
                if (data == true) {
                    PresentClosableBootstrapAlert("#alert_placeholder_register", "warning", "Invalid Email", "This email already exists!")
                }
                else {
                    CloseAlert("#alert_placeholder_register");
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;

                PresentClosableBootstrapAlert("#alert_placeholder_register", "danger", "Error!", errorText);

                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responceText);
            }
        });
    });


    var registerUserBtn = $("#RegistrationModal button[name = 'register']").click(onUserRegisterClick);

    function onUserRegisterClick() {
        var url = "UserAuth/RegisterUser";

        var antiForgeryToken = $("#RegistrationModal input[name='__RequestVerificationToken']").val();
        var email = $("#RegistrationModal input[name = 'Email']").val();
        var firstName = $("#RegistrationModal input[name = 'FirstName']").val();
        var lastName = $("#RegistrationModal input[name = 'LastName']").val();
        var password = $("#RegistrationModal input[name = 'Password']").val();
        var confirmPassword = $("#RegistrationModal input[name = 'ConfirmPassword']").val();
        
        var userInput = {
            __RequestVerificationToken: antiForgeryToken,
            Email: email,
            FirstName: firstName,
            LastName: lastName,
            Password: password,
            ConfirmPassword: confirmPassword
        };

        $.ajax({
            type: "POST",
            url: url,
            data: userInput,
            success: function (data) {

                var parsed = $.parseHTML(data);


                var hasErrors = $(parsed).find("input[name='RegistrationInValid']").val() == "true";

                if (hasErrors == true) {
                    $("#RegistrationModal").html(data);

                    registerUserBtn = $("#RegistrationModal button[name='login']").click(onUserLoginClick);

                    var form = $("#RegistrationForm");

                    $(form).removeData("validator");
                    $(form).removeData("unobtrusiveValidation");
                    $.validator.unobtrusive.parse(form);
                }
                else {
                    location.href = 'Home/Index';
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;

                PresentClosableBootstrapAlert("#alert_placeholder_register", "danger", "Error!", errorText);

                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responceText);
            }
        });
    }
});