ko.bindingHandlers.callFunction = {
    init: function (element, valueAccessor) {
        var value = ko.unwrap(valueAccessor());
        value();
    }
};