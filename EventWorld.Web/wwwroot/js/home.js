var EventWorld = EventWorld || {};

EventWorld.Home = (function ($, ko) {

    function AppData() {
        var self = this;
        self.events = ko.observableArray([]);
        self.getEvents = function () {
            $.ajax({
                url: "/Home/GetSliderEvents",
                type: "GET",
                success: function (result) {
                    self.events(result);
                }
            });
        };
    }

    return {
        init: function () {
            ko.applyBindings(new AppData(), document.getElementById("home-model"));
        }
    };
})(jQuery, ko);