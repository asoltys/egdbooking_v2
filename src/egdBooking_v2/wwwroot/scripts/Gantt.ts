namespace Gantt {
    var data: SimpleRow[];

    export class initializer {
        url: string;
        data: SimpleRow[];
        core: UI;

        constructor(url: string, containerId: string) {
            this.url = url;
            this.core = new UI(containerId);
            data = new Array();
            // it would be ideal if we can use Promise object instead of callback, but IE11
            //  doesn't support ES5&6 Promise object, so we should stick with callback hell
            // TODO: add progress bar while loading data
            Utils.getJSON(this.url, this.setData);
        }

        // Arrow function makes it safe to pass this function around (binds this)
        setData = (json: string): void => {
            var temp = JSON.parse(json);
            for (var i = 0; i < temp.length; i++) {
                data.push(new SimpleRow().deserialize(temp[i]));
            }
            this.core.render();
        }
    }

    export class UI {
        initialized: boolean;
        container: HTMLElement;
        ganttId: string = 'gantt-plugin-wrap';
        chartContainerId: string = 'gantt-plugin-chart-container';
        accessibleContainerId: string = 'gantt-plugin-accessible-container';
        chartContainer: HTMLElement;
        accessibleContainer: HTMLElement;

        constructor(containerId: string) {
            if (!document.getElementById(containerId)) {
                this.initialized = false;
                throw new Error(`Specified container Id "${containerId}" does not exist in DOM.`);
            }
            this.container = document.getElementById(containerId);
            this.initialized = true;
        }

        render() {
            this.addContainer();
            this.addTabs();
            this.renderChart();
            this.renderAccessible();
        }

        addContainer() {
            const markup = `
                <div id="${this.ganttId}" class="container-fluid">
                </div>
            `;
            this.container.innerHTML = markup;
        }

        addTabs() {
            const markup = `
                <div id="${this.ganttId}-tabs" class="wb-tabs print-active">
                    <div class="tabpanels">
                        <details id="${this.ganttId}-chart-tab" open="open">
                            <summary>Chart</summary>
                            <div id="${this.chartContainerId}" class="row"></div>
                        </details>
                        <details id="${this.ganttId}-accessible-tab">
                            <summary>Text</summary>
                            <div id="${this.accessibleContainerId}" class="row"></div>
                        </details>
                    </div>
                </div>
            `;
            document.getElementById(this.ganttId).innerHTML = markup;
            this.chartContainer = document.getElementById(this.chartContainerId);
            this.accessibleContainer = document.getElementById(this.accessibleContainerId);
        }

        renderChart() {
            console.log(data);
        }

        renderAccessible() {
        }
    }
}