export interface BookingHistory {
    id?: number;
    email: string;
    bookingDate?: Date;
    bookingTime: string;
    fromPlace?: number;
    toPlace?: number;
    pickupAddress: string;
    landmark: string;
    pickupDate?: Date;
    pickupTime: string;
    cabTypeId?: number;
    contactNo: string;
    status: string;
    comp_time: string;
    charge?: number;
    feedback: string;
}
