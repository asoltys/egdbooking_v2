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