'use strict';
var Utils = (function () {
    function Utils() {
    }
    Utils.getJSON = function (url, callback) {
        var request = new XMLHttpRequest();
        request.open('GET', url, true);
        request.onload = function () {
            if (request.status >= 200 && request.status < 400) {
                // Success!
                if (typeof callback === 'undefined') {
                    return request.responseText;
                }
                else {
                    callback(request.responseText);
                }
            }
            else {
            }
        };
        request.onerror = function () {
            // There was a connection error of some sort
        };
        request.send();
    };
    Utils.trigger = function (elemId, eventType) {
        var event;
        if (document.createEvent) {
            event = document.createEvent("HTMLEvents");
            event.initEvent(eventType, true, true);
        }
        else {
            throw new Error("document.createEvent is not supported in this browser...");
        }
        event.eventName = eventType;
        document.getElementById(elemId).dispatchEvent(event);
    };
    return Utils;
}());
//# sourceMappingURL=Utils.js.map