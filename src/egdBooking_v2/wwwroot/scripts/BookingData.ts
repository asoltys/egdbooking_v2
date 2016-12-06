'use strict';

interface Serializable<T> {
    deserialize(input: Object): T;
}

export class SimpleBookingData implements Serializable<SimpleBookingData> {
    id: number;
    vesselId: number;
    startDate: Date;
    endDate: Date;
    bookingTime: Date;
    status: string;

    deserialize(input: any) {
        this.id = input.id;
        this.vesselId = input.vid;
        this.startDate = input.sd;
        this.endDate = input.ed;
        this.bookingTime = input.bt;
        this.status = input.st;
        return this;
    }
}

export class SimpleRow implements Serializable<SimpleRow> {
    id: number;
    description: string;
    bookings: SimpleBookingData[] = [];

    deserialize(input: any) {
        this.id = input.id;
        this.description = input.desc;
        for (let booking of input.bookings) {
            this.bookings.push(new SimpleBookingData().deserialize(booking));
        }
        return this;
    }
}
