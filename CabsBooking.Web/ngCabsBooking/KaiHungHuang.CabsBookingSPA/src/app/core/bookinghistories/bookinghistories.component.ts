import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookinghistoryService } from '../services/bookinghistory.service';
import { CabtypeService } from '../services/cabtype.service';
import { PlaceService } from '../services/place.service';
import { BookingHistory } from '../shared/models/bookinghistory';
import { CabType } from '../shared/models/cabtype';
import { Place } from '../shared/models/place';

@Component({
  selector: 'app-bookinghistories',
  templateUrl: './bookinghistories.component.html',
  styleUrls: ['./bookinghistories.component.css']
})
export class BookinghistoriesComponent implements OnInit {

  bookingHistory: BookingHistory = {
    email: "",
    bookingTime: "",
    pickupAddress: "",
    landmark: "",
    pickupTime: "",
    contactNo: "",
    status: "",
    comp_time: "",
    feedback: "",
  }

  places: Place[] = [];
  cabTypes: CabType[] = [];

  bookingHistories: BookingHistory[] = [];
  constructor(
    private bookingHistoryService:BookinghistoryService,
    private placeService:PlaceService,
    private cabTypeService:CabtypeService,
    private router: Router,
  ) { }

  loadData() {
    this.bookingHistoryService.getAllBookingHistories().subscribe((bh)=>{
      this.bookingHistories = bh;
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

  createBookingHistory() {
    this.bookingHistoryService.createBookingHistory(this.bookingHistory).subscribe(
      (response) => {
        this.router.navigate(["/bookinghistory"]);
        this.loadData();
        this.bookingHistory = {
          email: "",
          bookingTime: "",
          pickupAddress: "",
          landmark: "",
          pickupTime: "",
          contactNo: "",
          status: "",
          comp_time: "",
          feedback: "",
        }
      },
      (err: any) => {
        console.log(err);
      }
    );
  }

  updateBookingHistory() {
    this.bookingHistoryService.updateBookingHistory(this.bookingHistory).subscribe(
      (response) => {
        console.log(response);
        this.router.navigate(["/bookinghistory"]);
        this.loadData();
        this.bookingHistory = {
          email: "",
          bookingTime: "",
          pickupAddress: "",
          landmark: "",
          pickupTime: "",
          contactNo: "",
          status: "",
          comp_time: "",
          feedback: "",
        }
      },
      (err: any) => {
        console.log(err);
      }
    );
  }

  getBookingHistory(id:number) {
    this.bookingHistoryService.getBookingHistoryById(id).subscribe((bh)=>{
      this.bookingHistory = bh;
    });
  }

  deleteBookingHistory(Id:number) {
    this.bookingHistoryService.deleteBookingHistory(Id).subscribe(
      (response) => {
        console.log(response);
        this.router.navigate(["/bookinghistory"]);
        this.loadData();
      },
      (err: any) => {
        console.log(err);
      }
    )
  }

  BookingHistoryAction() {
    if(this.bookingHistory.id==null)
      this.createBookingHistory();
    else
      this.updateBookingHistory();
  }

}
