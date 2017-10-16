// helper for Namespace pattern

var Patterns = {
    // ** namespace pattern
    namespace: function (name) {

        // ** single var pattern
        var parts = name.split(".");
        var ns = this;

        // ** iterator pattern
        for (var i = 0, len = parts.length; i < len; i++) {
            // ** || idiom
            ns[parts[i]] = ns[parts[i]] || {};
            ns = ns[parts[i]];
        }

        return ns;
    }
};

// general puspose utilities

Patterns.namespace("Store").Utils = (function () {

    // stops default events 
    var stopEvent = function (event) {
        event.preventDefault();
        event.stopPropagation();
        return false;
    }

    return {
        stopEvent: stopEvent
    }

})();

// application specific shared code

Patterns.namespace("Store").App = (function () {

    var updateCartOnPage = function (delta) {

        //update cart display

        var cartCount = $("#cartcount");
        var currentCount = parseInt(cartCount.text(), 10);

        if (isNaN(currentCount)) {
            currentCount = 0;
        }

        var count = currentCount + delta;

        if (count < 0) count = 0;

        cartCount.text(count);

        if (count === 0) {
            cartCount.removeClass("progress-bar-danger")
                     .css("color", "#666666");
        }
        else {
            cartCount.addClass("progress-bar-danger")
                     .css("color", "#fff");
        }
    };

    return {
        updateCartOnPage: updateCartOnPage
    };

})();