var EventWorld = EventWorld || {};

EventWorld.Chat = (function ($, ko) {

    function AppData() {
        var self = this;
        self.events = ko.observableArray([]);
        self.messageTextBox = ko.observable("");
        self.currentEventId = ko.observable("");
        self.messages = ko.observableArray([]);
        self.signalRConnection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
        self.signalRConnection.on("ReceiveMessage", function (message) {
            if (message.eventId === self.currentEventId()) {
                self.messages.unshift(message);
            }
        });
        self.signalRConnection.start().then(function () {
        }).catch(function (err) {
            return console.error(err.toString());
        });
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
                    self.signalRConnection.invoke("SendMessage", result).catch(function (err) {
                        return console.error(err.toString());
                    });
                    self.messageTextBox("");
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

    return {
        init: function () {
            ko.applyBindings(new AppData(), document.getElementById("chat-model"));
        }
    };
})(jQuery, ko);