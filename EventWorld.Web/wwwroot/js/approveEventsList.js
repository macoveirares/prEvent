var EventWorld = EventWorld || {};

EventWorld.ApproveEventsList = (function ($, ko) {

    function AppData() {
        var self = this;
        self.events = ko.observableArray([]);
        self.isAjaxCallRunning = ko.observable(false);
        self.goToEventList = function () {
            window.location.href = "List";
        };
        self.goToDetails = function () {
            window.location.href = "Details?id=" + this.id + "&isAdmin=True";
        };
        self.getEvents = function () {
            self.isAjaxCallRunning(true);
            $.ajax({
                url: "/Event/GetEventsToApprove",
                type: "GET",
                success: function (result) {
                    self.isAjaxCallRunning(false);
                    self.events(result);
                }
            });
        };
    }

    return {
        init: function () {
            ko.applyBindings(new AppData(), document.getElementById("events-to-approve-model"));
        }
    };
})(jQuery, ko);