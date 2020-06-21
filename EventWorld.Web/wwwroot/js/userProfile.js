var EventWorld = EventWorld || {};

EventWorld.UserProfile = (function ($, ko) {

    function AppData() {
        var self = this;
        var userdId = window.location.pathname.substring(window.location.pathname.lastIndexOf('/') + 1);
        if (isNaN(userdId)) {
            userdId = null;
        }
        self.userId = ko.observable(userdId);
        self.user = ko.observable("");
        self.userAttendedEvents = ko.observableArray([]);
        self.userUpcomingEvents = ko.observableArray([]);
        self.isAjaxCallRunning = ko.observable(false);
        self.getUser = function () {
            $.ajax({
                url: "/User/GetUserProfile",
                type: "GET",
                data: {
                    id: self.userId()
                },
                success: function (result) {
                    self.user(result.userInfo);
                    self.userAttendedEvents(result.userAttendedEvents);
                    if (result.userEvents !== typeof ('undefined')) {
                        self.userUpcomingEvents(result.userEvents);
                    }
                }
            });
        };
    }

    return {
        init: function () {
            ko.applyBindings(new AppData(), document.getElementById("user-profile-model"));
        }
    };
})(jQuery, ko);