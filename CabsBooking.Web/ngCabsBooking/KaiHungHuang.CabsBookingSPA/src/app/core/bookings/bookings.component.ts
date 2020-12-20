import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookingService } from '../services/booking.service';
import { CabtypeService } from '../services/cabtype.service';
import { PlaceService } from '../services/place.service';
import { Booking } from '../shared/models/booking';
import { CabType } from '../shared/models/cabtype';
import { Place } from '../shared/models/place';

@Component({
  selector: 'app-bookings',
  templateUrl: './bookings.component.html',
  styleUrls: ['./bookings.component.css']
})
export class BookingsComponent implements OnInit {
  booking: Booking = {
    email: "",
    bookingTime: "",
    pickupAddress: "",
    landmark: "",
    pickupTime: "",
    contactNo: "",
    status: "",
    cabTypeName: "",
    toPlaceName: "",
    fromPlaceName: "",
  }

  places: Place[] = [];
  cabTypes: CabType[] = [];
  bookings: Booking[] = [];

  constructor(
    private bookingService: BookingService,
    private placeService: PlaceService,
    private cabTypeService: CabtypeService,
    private router: Router,
  ) { }

  loadData() {
    this.bookingService.getAllBookings().subscribe((bh)=>{
      this.bookings = bh;
    });
    this.placeService.getAllPlaces().subscribe((p)=>{
      this.places = p;
    });
    this.cabTypeService.getAllCabTypes().subscribe((c)=>{
      this.cabTypes = c;
    })
  }
  ngOnInit(): void {
    this.loadData();
  }

  createBooking() {
    this.bookingService.createBooking(this.booking).subscribe(
      (response) => {
        this.router.navigate(["/booking"]);
        this.loadData();
        this.booking = {
          email: "",
          bookingTime: "",
          pickupAddress: "",
          landmark: "",
          pickupTime: "",
          contactNo: "",
          status: "",
          cabTypeName: "",
          toPlaceName: "",
          fromPlaceName: "",
        }
      },
      (err: any) => {
        console.log(err);
      }
    );
  }

  updateBooking() {
    this.bookingService.updateBooking(this.booking).subscribe(
      (response) => {
        console.log(response);
        this.router.navigate(["/booking"]);
        this.loadData();
        this.booking = {
          email: "",
          bookingTime: "",
          pickupAddress: "",
          landmark: "",
          pickupTime: "",
          contactNo: "",
          status: "",
          cabTypeName: "",
          toPlaceName: "",
          fromPlaceName: "",
        }
      },
      (err: any) => {
        console.log(err);
      }
    );
  }

  deleteBooking(Id:number) {
    this.bookingService.deleteBooking(Id).subscribe(
      (response) => {
        console.log(response);
        this.router.navigate(["/booking"]);
        this.loadData();
      },
      (err: any) => {
        console.log(err);
      }
    )
  }

  getBooking(id:number) {
    this.bookingService.getById(id).subscribe((b)=>{
      this.booking = b;
    });
  }

  BookingAction() {
    if(this.booking.id==null)
      this.createBooking();
    else
      this.updateBooking();
  }
}
