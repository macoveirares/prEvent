var EventWorld = EventWorld || {};

EventWorld.Feedback = (function ($, ko) {

    function AppData() {
        var self = this;
        var queryParams = window.location.search.substring(1).split('&').reduce(function (result, param) {
            var [key, value] = param.split("=");
            result[key] = value;
            return result;
        }, {});
        self.eventId = ko.observable(queryParams["id"]);
        self.users = ko.observableArray([]);
        self.goToEventList = function () {
            window.location.href = "List";
        };
        self.submitRating = function (data, event) {
            var userId = this.id;
            $.ajax({
                url: "/User/SubmitFeedback",
                type: "POST",
                data: {
                    eventId: self.eventId(),
                    userId: userId,
                    rating: $(event.currentTarget).attr("data-rating")
                },
                success: function () {
                    self.users.remove(function (item) { return item.id === userId; });
                }
            });
        };
        self.getUsers = function () {
            $.ajax({
                url: "/Event/GetUsersThatAttendedEvent",
                type: "GET",
                data: {
                    id: self.eventId()
                },
                success: function (result) {
                    self.users(result);
                }
            });
        };
    }

    return {
        init: function () {
            ko.applyBindings(new AppData(), document.getElementById("feedback-model"));
        }
    };
})(jQuery, ko);