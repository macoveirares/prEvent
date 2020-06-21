var EventWorld = EventWorld || {};

EventWorld.EventDetails = (function ($, ko, alertify) {

    function AppData() {
        var self = this;
        var queryParams = window.location.search.substring(1).split('&').reduce(function (result, param) {
            var [key, value] = param.split("=");
            result[key] = value;
            return result;
        }, {});
        self.isAdmin = ko.observable(queryParams["isAdmin"] === "True");
        self.eventId = ko.observable(queryParams["id"]);
        self.event = ko.observable("");
        self.isUserAttending = ko.observable(false);
        self.isAjaxCallRunning = ko.observable(false);
        self.goToApproveAttends = function () {
            window.location.href = "/Event/ApproveAttends?id=" + self.eventId();
        };
        self.deleteEvent = function () {
            self.isAjaxCallRunning(true);
            $.ajax({
                url: "/Event/DeleteEvent",
                type: "DELETE",
                data: {
                    id: self.eventId()
                },
                success: function () {
                    self.isAjaxCallRunning(false);
                    window.location.href = "/Event/List";
                }
            });
        };
        self.attendEvent = function () {
            self.isAjaxCallRunning(true);
            $.ajax({
                url: "/Event/AttendEvent",
                type: "POST",
                data: {
                    id: self.eventId()
                },
                success: function () {
                    self.isAjaxCallRunning(false);
                    window.location.href = "/Event/List";
                }
            });
        };
        self.approveEvent = function () {
            self.isAjaxCallRunning(true);
            $.ajax({
                url: "/Event/ApproveEvent",
                type: "POST",
                data: {
                    id: self.eventId()
                },
                success: function (result) {
                    self.isAjaxCallRunning(false);
                    if (result === true) {
                        window.location.href = "/Event/ApproveList";
                    }
                    else {
                        alertify.alert(result);
                    }                   
                }
            });
        };
        self.rejectEvent = function () {
            self.isAjaxCallRunning(true);
            $.ajax({
                url: "/Event/RejectEvent",
                type: "POST",
                data: {
                    id: self.eventId()
                },
                success: function (result) {
                    self.isAjaxCallRunning(false);
                    if (result === true) {
                        window.location.href = "/Event/ApproveList";
                    }
                    else {
                        alertify.alert(result);
                    }         
                }
            });
        };
        self.getEvent = function () {
            $.ajax({
                url: "/Event/GetEvent",
                type: "GET",
                data: {
                    id: self.eventId()
                },
                success: function (result) {
                    self.event(result.currentEvent);
                    self.isUserAttending(result.isUserAttending);
                }
            });
        };
    }

    return {
        init: function () {
            ko.applyBindings(new AppData(), document.getElementById("event-model"));
        }
    };
})(jQuery, ko, alertify);