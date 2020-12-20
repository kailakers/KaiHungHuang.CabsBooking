import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BookingHistory } from '../shared/models/bookinghistory';
import { ApiService } from './api.service';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BookinghistoryService {

  constructor(private apiService: ApiService) { }

  getAllBookingHistories(): Observable<BookingHistory[]> {
    return this.apiService.getAll('BookingHistory/allBookingHistory');
  }

  createBookingHistory(bookingHistory: BookingHistory): Observable<Boolean> {
    return this.apiService.create('BookingHistory/createBookingHistory', bookingHistory).pipe(
      map((response) => {
        if(response){
          console.log(response);
          return true;
        }
        return false;
      })
    );
  }

  updateBookingHistory(bookingHistory: BookingHistory): Observable<Boolean> {
    return this.apiService.update('BookingHistory/updateBookingHistory', bookingHistory).pipe(
      map((response) => {
        if(response){
          console.log(response);
          return true;
        }
        return false;
      })
    );
  }

  deleteBookingHistory(id: number): Observable<Boolean> {
    return this.apiService.delete('BookingHistory/deleteBookingHistory', id).pipe(
      map((response) => {
        if(response){
          return true;
        }
        return false;
      })
    );
  }

  getBookingHistoryById(id: number): Observable<BookingHistory> {
    return this.apiService.getById('BookingHistory/', id);
  }
}
