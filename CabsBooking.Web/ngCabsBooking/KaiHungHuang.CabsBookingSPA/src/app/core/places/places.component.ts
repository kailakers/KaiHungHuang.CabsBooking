import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PlaceService } from '../services/place.service';
import { Place } from '../shared/models/place';

@Component({
  selector: 'app-places',
  templateUrl: './places.component.html',
  styleUrls: ['./places.component.css']
})
export class PlacesComponent implements OnInit {
  place: Place = {
    placeName: "",
  }

  places: Place[] = [];
  constructor(
    private placeService:PlaceService,
    private router: Router,
  ) { }

  loadData() {
    this.placeService.getAllPlaces().subscribe((p)=>{
      this.places = p;
      console.table(this.places);
    });
  }
  ngOnInit(): void {
    this.loadData();
  }

  

  createPlace() {
    this.placeService.createPlaces(this.place).subscribe(
      (response) => {
        this.router.navigate(["/place"]);
        this.loadData();
        this.place = {
          placeName: ""
        }
      },
      (err: any) => {
        console.log(err);
      }
    );
  }

  updatePlace() {
    this.placeService.updatePlace(this.place).subscribe(
      (response) => {
        this.router.navigate(["/place"]);
        this.loadData();
        this.place = {
          placeName: ""
        }
      },
      (err: any) => {
        console.log(err);
      }
    );
  }

  getPlace(id: number) {
    this.placeService.getPlaceById(id).subscribe(p=>{
      this.place = p;
    });
  }

  deletePlace(placeId:number) {
    this.placeService.deletePlace(placeId).subscribe(
      (response) => {
        this.router.navigate(["/place"]);
        this.loadData();
      },
      (err: any) => {
        console.log(err);
      }
    );
  }

  placeAction() {
    if (this.place.placeId == null)
      this.createPlace();
    else
      this.updatePlace();
  }
}
