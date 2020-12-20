import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookingService } from '../../services/booking.service';
import { Booking } from '../../shared/models/booking';

@Component({
  selector: 'app-cabtype-details',
  templateUrl: './cabtype-details.component.html',
  styleUrls: ['./cabtype-details.component.css']
})
export class CabtypeDetailsComponent implements OnInit {
  bookings: Booking[] = [];
  cabtypeId?: number;
  cabTypeName: string;
  constructor(
    private bookingService:BookingService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((p)=>{
      this.cabtypeId = +p.get('id');
      this.bookingService.getBookingByCabType(this.cabtypeId).subscribe((m)=>{
        this.bookings = m;
        console.table(this.bookings);
      })
    })
  }

}
