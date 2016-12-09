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
    return Utils;
}());
//# sourceMappingURL=Utils.js.map