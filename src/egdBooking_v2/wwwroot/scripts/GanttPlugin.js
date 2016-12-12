'use strict';
var SimpleBookingData = (function () {
    function SimpleBookingData() {
    }
    SimpleBookingData.prototype.deserialize = function (input) {
        this.id = input.id;
        this.vesselId = input.vid;
        this.startDate = input.sd;
        this.endDate = input.ed;
        this.bookingTime = input.bt;
        this.status = input.st;
        return this;
    };
    return SimpleBookingData;
}());
var SimpleRow = (function () {
    function SimpleRow() {
        this.bookings = [];
    }
    SimpleRow.prototype.deserialize = function (input) {
        this.id = input.id;
        this.description = input.desc;
        for (var _i = 0, _a = input.bookings; _i < _a.length; _i++) {
            var booking = _a[_i];
            this.bookings.push(new SimpleBookingData().deserialize(booking));
        }
        return this;
    };
    return SimpleRow;
}());
//# sourceMappingURL=BookingData.js.map
var Gantt;
(function (Gantt) {
    var data;
    var initializer = (function () {
        function initializer(url, containerId) {
            var _this = this;
            // Arrow function makes it safe to pass this function around (binds this)
            this.setData = function (json) {
                var temp = JSON.parse(json);
                for (var i = 0; i < temp.length; i++) {
                    data.push(new SimpleRow().deserialize(temp[i]));
                }
                _this.core.render();
            };
            this.url = url;
            this.core = new UI(containerId);
            data = new Array();
            // it would be ideal if we can use Promise object instead of callback, but IE11
            //  doesn't support ES5&6 Promise object, so we should stick with callback hell
            // TODO: add progress bar while loading data
            Utils.getJSON(this.url, this.setData);
        }
        return initializer;
    }());
    Gantt.initializer = initializer;
    var UI = (function () {
        function UI(containerId) {
            this.ganttId = 'gantt-plugin-wrap';
            this.chartContainerId = 'gantt-plugin-chart-container';
            this.accessibleContainerId = 'gantt-plugin-accessible-container';
            if (!document.getElementById(containerId)) {
                this.initialized = false;
                throw new Error("Specified container Id \"" + containerId + "\" does not exist in DOM.");
            }
            this.container = document.getElementById(containerId);
            this.initialized = true;
        }
        UI.prototype.render = function () {
            this.addContainer();
            this.addTabs();
            this.renderChart();
            this.renderAccessible();
        };
        UI.prototype.addContainer = function () {
            var markup = "\n                <div id=\"" + this.ganttId + "\" class=\"container-fluid\">\n                </div>\n            ";
            this.container.innerHTML = markup;
        };
        UI.prototype.addTabs = function () {
            var markup = "\n                <div id=\"" + this.ganttId + "-tabs\" class=\"wb-tabs print-active\">\n                    <div class=\"tabpanels\">\n                        <details id=\"" + this.ganttId + "-chart-tab\" open=\"open\">\n                            <summary>Chart</summary>\n                            <div id=\"" + this.chartContainerId + "\" class=\"row\"></div>\n                        </details>\n                        <details id=\"" + this.ganttId + "-accessible-tab\">\n                            <summary>Text</summary>\n                            <div id=\"" + this.accessibleContainerId + "\" class=\"row\"></div>\n                        </details>\n                    </div>\n                </div>\n            ";
            document.getElementById(this.ganttId).innerHTML = markup;
            this.chartContainer = document.getElementById(this.chartContainerId);
            this.accessibleContainer = document.getElementById(this.accessibleContainerId);
        };
        UI.prototype.renderChart = function () {
            console.log(data);
        };
        UI.prototype.renderAccessible = function () {
        };
        return UI;
    }());
    Gantt.UI = UI;
})(Gantt || (Gantt = {}));
//# sourceMappingURL=Gantt.js.map
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