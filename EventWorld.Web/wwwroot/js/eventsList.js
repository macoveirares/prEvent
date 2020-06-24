var EventWorld = EventWorld || {};

EventWorld.EventsList = (function ($, ko) {

    function AppData() {
        var self = this;
        self.searchTextBox = ko.observable("");
        self.categoryDropDown = ko.observable("");
        self.categories = ko.observableArray([]);
        self.events = ko.observableArray([]);
        self.isAjaxCallRunning = ko.observable(false);
        self.goToCreateEvent = function () {
            window.location.href = "Create";
        };
        self.goToApproveEvents = function () {
            window.location.href = "ApproveList";
        };
        self.goToDetails = function () {
            window.location.href = "Details?id=" + this.id;
        };
        self.getCategories = function () {
            $.ajax({
                url: "/Event/GetEventTypes",
                type: "GET",
                success: function (result) {
                    self.categories(result);
                }
            });
        };
        self.getEvents = function () {
            self.isAjaxCallRunning(true);
            $.ajax({
                url: "/Event/GetEvents",
                type: "GET",
                data: {
                    searchTerm: self.searchTextBox(),
                    categoryId: self.categoryDropDown(),
                    listCount: self.events().length
                },
                success: function (result) {
                    self.isAjaxCallRunning(false);
                    if (self.events().length > 0 && self.searchTextBox() === "") {
                        self.events(self.events().concat(result.events));
                    }
                    else {
                        self.events(result.events);
                    }

                    if (!result.areMoreEvents) {
                        self.removeScrollHandler();
                    }

                }
            });
        };

        var keyTimer;

        self.searchTextBox.subscribe(function () {
            if (keyTimer) {
                clearTimeout(keyTimer);
            }
            keyTimer = setTimeout(function () {
                self.events([]);
                self.getEvents();
            }, 700);
        });

        self.categoryDropDown.subscribe(function () {
            self.events([]);
            self.getEvents();
        });
        self.addScrollHandler = function () {
            $(window).bind('scroll', function (event) {
                var win = $(this),
                    doc = $(document),
                    winH = win.height(),
                    winT = win.scrollTop(),
                    docH = doc.height(),
                    interval = parseInt(winH * 0.2, 10);

                if (docH - winH - winT < interval && !self.isAjaxCallRunning()) {
                    self.getEvents();
                }

            });
        };
        self.removeScrollHandler = function () {
            $(window).unbind('scroll');
        };
        self.addScrollHandler();
    }

    return {
        init: function () {
            ko.applyBindings(new AppData(), document.getElementById("events-model"));
        }
    };
})(jQuery, ko);