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