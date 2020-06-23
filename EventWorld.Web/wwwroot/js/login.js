var EventWorld = EventWorld || {};

EventWorld.Login = (function ($, ko, alertify) {

    function AppData() {
        var self = this;
        self.emailTextBox = ko.observable("");
        self.passwordTextBox = ko.observable("");
        self.isAjaxCallRunning = ko.observable(false);
        self.isEmailValid = ko.pureComputed(function () {
            var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(String(self.emailTextBox()).toLowerCase());
        });
        self.isPasswordValid = ko.pureComputed(function () {
            return self.passwordTextBox() !== "";
        });
        self.isButtonEnabled = ko.pureComputed(function () {
            return self.isEmailValid() && self.isPasswordValid();
        });
        self.loginAction = function () {
            self.isAjaxCallRunning(true);
            $.ajax({
                url: "/Account/Login",
                type: "POST",
                data: {
                    email: self.emailTextBox(),
                    password: self.passwordTextBox()
                },
                success: function (result) {
                    self.isAjaxCallRunning(false);
                    if (result.isSuccess === true) {
                        if (result.eventId) {
                            window.location.href = "/Event/Feedback?id=" + result.eventId;
                        }
                        else {
                            window.location.href = "/Home/Index";
                        }
                    }
                    else {
                        alertify.alert(result.error);
                    }
                }
            });
        };
    }

    return {
        init: function () {
            ko.applyBindings(new AppData(), document.getElementById("login-model"));
        }
    };
})(jQuery, ko, alertify);