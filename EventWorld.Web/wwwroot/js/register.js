var EventWorld = EventWorld || {};

EventWorld.Register = (function ($, ko, alertify) {

    function isFutureDate(idate) {
        var today = new Date().getTime();
        idate = idate.split("-");

        idate = new Date(idate[0], idate[1] - 1, idate[2]).getTime();
        return (today - idate) < 0;
    }

    function AppData() {
        var self = this;
        self.emailTextBox = ko.observable("");
        self.passwordTextBox = ko.observable("");
        self.firstNameTextBox = ko.observable("");
        self.lastNameTextBox = ko.observable("");
        self.dateOfBirthTextBox = ko.observable("");
        self.confirmPasswordTextBox = ko.observable("");
        self.isAjaxCallRunning = ko.observable(false);
        self.isEmailValid = ko.pureComputed(function () {
            var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(String(self.emailTextBox()).toLowerCase());
        });
        self.isPasswordValid = ko.pureComputed(function () {
            return self.passwordTextBox() !== "";
        });
        self.isFirstNameValid = ko.pureComputed(function () {
            return self.firstNameTextBox() !== "";
        });
        self.isLastNameValid = ko.pureComputed(function () {
            return self.lastNameTextBox() !== "";
        });
        self.isBirthdayValid = ko.pureComputed(function () {
            return self.dateOfBirthTextBox() !== "" && !isFutureDate(self.dateOfBirthTextBox());
        });
        self.isConfirmPasswordValid = ko.pureComputed(function () {
            return self.confirmPasswordTextBox() !== "" && self.confirmPasswordTextBox() === self.passwordTextBox();
        });
        self.isButtonEnabled = ko.pureComputed(function () {
            return self.isEmailValid() && self.isPasswordValid() && self.isFirstNameValid() && self.isLastNameValid() && self.isBirthdayValid() && self.isConfirmPasswordValid();
        });
        self.registerAction = function () {
            self.isAjaxCallRunning(true);
            $.ajax({
                url: "/Account/Register",
                type: "POST",
                data: {
                    Email: self.emailTextBox(),
                    Password: self.passwordTextBox(),
                    FirstName: self.firstNameTextBox(),
                    LastName: self.lastNameTextBox(),
                    DateOfBirth: self.dateOfBirthTextBox(),
                    ConfirmPassword: self.confirmPasswordTextBox()
                },
                success: function (result) {
                    self.isAjaxCallRunning(false);
                    if (result === true) {
                        window.location.href = "/Account/SignIn";
                    }
                    else {
                        alertify.alert(result);
                    }
                }
            });
        };
    }

    return {
        init: function () {
            ko.applyBindings(new AppData(), document.getElementById("register-model"));
        }
    };
})(jQuery, ko, alertify);