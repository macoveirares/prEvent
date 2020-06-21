var EventWorld = EventWorld || {};

EventWorld.CreateEvent = (function ($, ko, alertify) {

    function isFutureDate(value) {
        return new Date().getTime() <= new Date(value).getTime();
    }

    function AppData() {
        var self = this;
        self.titleTextBox = ko.observable("");
        self.descriptionTextBox = ko.observable("");
        self.categoryDropDown = ko.observable("");
        self.dateTextBox = ko.observable("");
        self.locationTextBox = ko.observable("");
        self.ageRequiredTextBox = ko.observable("");
        self.categories = ko.observableArray([]);
        self.isAjaxCallRunning = ko.observable(false);
        self.isTitleValid = ko.pureComputed(function () {
            return self.titleTextBox() !== "" && self.titleTextBox().length < 50;
        });
        self.isDescriptionValid = ko.pureComputed(function () {
            return self.descriptionTextBox() !== "";
        });
        self.isCategoryValid = ko.pureComputed(function () {
            return self.categoryDropDown() !== "";
        });
        self.isDateValid = ko.pureComputed(function () {
            return self.dateTextBox() !== "" && isFutureDate(self.dateTextBox());
        });
        self.isLocationValid = ko.pureComputed(function () {
            return self.locationTextBox() !== "";
        });
        self.isAgeRequiredValid = ko.pureComputed(function () {
            return self.ageRequiredTextBox() !== "" && self.ageRequiredTextBox().length <= 2;
        });
        self.isButtonEnabled = ko.pureComputed(function () {
            return self.isTitleValid() && self.isDescriptionValid() && self.isCategoryValid() && self.isDateValid() && self.isLocationValid() && self.isAgeRequiredValid() && !self.isAjaxCallRunning();
        });
        self.getCategories = function () {
            $.ajax({
                url: "/Event/GetEventTypes",
                type: "GET",
                success: function (result) {
                    self.categories(result);
                }
            });
        };

        self.createEvent = function () {
            self.isAjaxCallRunning(true);
            $.ajax({
                url: "/Event/CreateEvent",
                type: "POST",
                data: {
                    Title: self.titleTextBox(),
                    Description: self.descriptionTextBox(),
                    EventTypeId: self.categoryDropDown(),
                    Date: self.dateTextBox(),
                    Location: self.locationTextBox(),
                    AgeRequired: self.ageRequiredTextBox()
                },
                success: function (result) {
                    self.isAjaxCallRunning(false);
                    if (result === true) {
                        window.location.href = "/Event/List";
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
            ko.applyBindings(new AppData(), document.getElementById("create-model"));
        }
    };
})(jQuery, ko, alertify);