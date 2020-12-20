import { CabType } from "./cabtype";
import { Place } from "./place";

export interface Booking {
    id?: number;
    email: string;
    bookingDate?: Date;
    bookingTime: string;
    fromPlaceName: string;
    toPlaceName: string;
    pickupAddress: string;
    landmark: string;
    pickupDate?: Date;
    pickupTime: string;
    cabTypeName: string;
    contactNo: string;
    status: string;
    fromPlace?: Place;
    toPlace?: Place;
    cabTypeId?: number;
    cabType?: CabType;
}
