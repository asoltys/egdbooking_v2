class Gantt {
    constructor() {
        Utils.getJSON('http://localhost:23001/api/bookings', console.log);
    }
}
