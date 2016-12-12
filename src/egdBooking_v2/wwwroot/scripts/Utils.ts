'use strict';
class Utils {
    constructor() {
    }

    static getJSON(url: string, callback?: any): void {
        var request = new XMLHttpRequest();
        request.open('GET', url, true);

        request.onload = function () {
            if (request.status >= 200 && request.status < 400) {
                // Success!
                if (typeof callback === 'undefined') {
                    return request.responseText;
                } else {
                    callback(request.responseText);
                }
            } else {
                // We reached our target server, but it returned an error

            }
        };

        request.onerror = function () {
            // There was a connection error of some sort
        };
        request.send();
    }

    static trigger(elemId: string, eventType: string): void {
        var event;

        if (document.createEvent) {
            event = document.createEvent("HTMLEvents");
            event.initEvent(eventType, true, true);
        } else {
            throw new Error("document.createEvent is not supported in this browser...");
        }
        event.eventName = eventType;
        document.getElementById(elemId).dispatchEvent(event);
    }
}
