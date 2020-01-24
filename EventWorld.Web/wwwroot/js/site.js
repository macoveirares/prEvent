// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var EventWorld = EventWorld || {};

EventWorld.Identity = (function ($, ko) {

    function AppData() {
        var self = this;
        self.isAuthenticated = ko.observable($("#is-authenticated").val() === "True");
        self.firstName = ko.observable($("#first-name").val());
        self.lastName = ko.observable($("#last-name").val());
        self.dateOfBirth = ko.observable($("#date-of-birth").val());
        self.email = ko.observable($("#email").val());
        self.id = ko.observable($("#id").val());
        self.isAdmin = ko.observable($("#is-admin").val() === "True");
    }

    return {
        init: function () {
            ko.applyBindings(new AppData(), document.getElementById("ew-header"));
        }
    };
})(jQuery, ko);