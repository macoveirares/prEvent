var EventWorld = EventWorld || {};

EventWorld.Chat = (function ($, ko) {

    function AppData() {
        var self = this;
        self.events = ko.observableArray([]);
        self.messageTextBox = ko.observable("");
        self.currentEventId = ko.observable("");
        self.messages = ko.observableArray([]);
        self.getEvents = function () {
            $.ajax({
                url: "/User/GetUserEnrolledEvents",
                type: "GET",
                success: function (result) {
                    self.events(result);
                }
            });
        };
        self.getEventMessages = function (data, event) {
            $(event.currentTarget).addClass("selected");
            self.currentEventId($(event.currentTarget).attr("data-event-id"));
            $.ajax({
                url: "/Message/GetEventMessages",
                type: "GET",
                data: {
                    eventId: self.currentEventId()
                },
                success: function (result) {
                    self.messages(result);
                }
            });
        };
        self.sendMessage = function () {
            $.ajax({
                url: "/Message/SendMessage",
                type: "POST",
                data: {
                    eventId: self.currentEventId(),
                    text: self.messageTextBox()
                },
                success: function (result) {
                    self.messageTextBox("");
                    self.messages.unshift(result);
                }
            });
        };
        self.goToProfile = function () {
            if (this.id == $("#id").val()) {
                window.location.href = "/User/UserProfile";
            }
            else {
                window.location.href = "/User/UserProfile?id=" + this.id;
            }
        };
    }

    ko.bindingHandlers.enterkey = {
        init: function (element, valueAccessor, allBindings, viewModel) {
            var callback = valueAccessor();
            $(element).keypress(function (event) {
                var keyCode = (event.which ? event.which : event.keyCode);
                if (keyCode === 13) {
                    callback.call(viewModel);
                    return false;
                }
                return true;
            });
        }
    };

    return {
        init: function () {
            ko.applyBindings(new AppData(), document.getElementById("chat-model"));
        }
    };
})(jQuery, ko);