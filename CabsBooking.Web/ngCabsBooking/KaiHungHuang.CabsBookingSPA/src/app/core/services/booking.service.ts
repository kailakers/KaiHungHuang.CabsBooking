import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Booking } from '../shared/models/booking';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  constructor(private apiService:ApiService) { }

  getBookingByCabType(id: number): Observable<Booking[]> {
    return this.apiService.getAll('booking/cabtype', id);
  }

  getAllBookings(): Observable<Booking[]> {
    return this.apiService.getAll('Booking/allBookings');
  }

  createBooking(booking: Booking): Observable<Boolean> {
    return this.apiService.create('Booking/createBooking', booking).pipe(
      map((response) => {
        if(response){
          return true;
        }
        return false;
      })
    );
  }

  updateBooking(booking: Booking): Observable<Boolean> {
    return this.apiService.update('Booking/updateBooking', booking).pipe(
      map((response) => {
        if(response){
          return true;
        }
        return false;
      })
    );
  }

  // getOne
  getById(id: number): Observable<Booking> {
    return this.apiService.getById('Booking/', id);
  }

  deleteBooking(id: number): Observable<Boolean> {
    return this.apiService.delete('Booking/deleteBooking', id).pipe(
      map((response) => {
        if(response){
          return true;
        }
        return false;
      })
    );
  }
}
