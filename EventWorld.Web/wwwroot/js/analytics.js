var EventWorld = EventWorld || {};

EventWorld.Analytics = (function ($, ko) {

    function AppData() {
        var self = this;
        self.eventCounts = ko.observableArray([]);
        self.messagesCounts = ko.observableArray([]);
        self.enrollmentsCounts = ko.observableArray([]);
        self.getEventAnalysis = function () {
            $.ajax({
                url: "/Event/GetEventsAnalysis",
                type: "GET",
                success: function (result) {
                    self.eventCounts(result);
                    self.initEventsChart();
                }
            });
        };
        self.getMessagesAnalysis = function () {
            $.ajax({
                url: "/Message/GetMessagesAnalysis",
                type: "GET",
                success: function (result) {
                    self.messagesCounts(result);
                    self.initMessagesChart();
                }
            });
        };
        self.getEnrollmentsAnalysis = function () {
            $.ajax({
                url: "/User/GetUsersEnrollmentsAnalysis",
                type: "GET",
                success: function (result) {
                    self.enrollmentsCounts(result);
                    self.initEnrollmentsChart();
                }
            });
        };
        var labels = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
        self.initEventsChart = function () {
            var ctx = document.getElementById('eventsChart').getContext('2d');
            var chart = new Chart(ctx, {
                // The type of chart we want to create
                type: 'bar',
                // The data for our dataset
                data: {
                    labels: labels,
                    datasets: [{
                        label: 'Events created by month',
                        backgroundColor: 'rgb(255, 99, 132)',
                        borderColor: 'rgb(255, 99, 132)',
                        data: self.eventCounts()
                    }]
                }
            });
            chart.canvas.parentNode.style.width = '550px';
        };
        self.initMessagesChart = function () {
            var ctx = document.getElementById('messagesChart').getContext('2d');
            var chart = new Chart(ctx, {
                // The type of chart we want to create
                type: 'bar',

                // The data for our dataset
                data: {
                    labels: labels,
                    datasets: [{
                        label: 'Messages sent by month',
                        backgroundColor: 'rgb(20, 245, 80)',
                        borderColor: 'rgb(20, 245, 80)',
                        data: self.messagesCounts()
                    }]
                }
            });
            chart.canvas.parentNode.style.width = '550px';
        };
        self.initEnrollmentsChart = function () {
            var ctx = document.getElementById('participantsChart').getContext('2d');
            var chart = new Chart(ctx, {
                // The type of chart we want to create
                type: 'line',

                // The data for our dataset
                data: {
                    labels: labels,
                    datasets: [{
                        label: 'Enrollments made by month',
                        borderColor: 'rgb(19, 146, 237)',
                        data: self.enrollmentsCounts()
                    }]
                }
            });
            chart.canvas.parentNode.style.width = '550px';
        };
    }

    return {
        init: function () {
            ko.applyBindings(new AppData(), document.getElementById("analytics-model"));
        }
    };
})(jQuery, ko);