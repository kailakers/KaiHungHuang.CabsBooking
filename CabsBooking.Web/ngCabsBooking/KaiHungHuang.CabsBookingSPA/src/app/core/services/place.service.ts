import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Place } from '../shared/models/place';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class PlaceService {

  constructor(private apiService:ApiService) { }

  getAllPlaces(): Observable<Place[]> {
    return this.apiService.getAll('Place/getAllPlaces');
  }

  createPlaces(place: Place): Observable<Boolean> {
    return this.apiService.create('Place/createPlace', place).pipe(
      map((response)=>{
        if(response){
          console.log(response);
          return true;
        }
        return false;
      })
    );
  }

  updatePlace(place: Place): Observable<Boolean> {
    return this.apiService.update('Place/updatePlace', place).pipe(
      map((response)=>{
        if(response){
          console.log(response);
          return true;
        }
        return false;
      })
    );
  }

  deletePlace(placeId: number): Observable<Boolean>{
    return this.apiService.delete('Place/deletePlace', placeId).pipe(
      map((response)=>{
        if(response){
          console.log(response)
          return true;
        }
        return false;
      })
    );
  }
  
  getPlaceById(id:number): Observable<Place> {
    return this.apiService.getById('Place/', id);
  }
}
