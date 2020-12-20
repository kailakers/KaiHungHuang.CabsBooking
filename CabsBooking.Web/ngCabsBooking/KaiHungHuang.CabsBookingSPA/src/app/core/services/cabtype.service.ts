import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { CabType } from '../shared/models/cabtype';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class CabtypeService {


  constructor(private apiService:ApiService) { }

  getAllCabTypes(): Observable<CabType[]> {
    return this.apiService.getAll('CabType/allCabType');
  }

  createCabTypes(cabType: CabType): Observable<Boolean> {
    return this.apiService.create('CabType/createCabType', cabType).pipe(
      map((response)=>{
        if(response){
          console.log(response);
          return true;
        }
        return false;
      })
    );
  }

  updateCabType(cabType: CabType): Observable<Boolean> {
    return this.apiService.update('CabType/updateCabType', cabType).pipe(
      map((response)=>{
        if(response){
          console.log(response);
          return true;
        }
        return false;
      })
    );
  }

  deleteCabType(cabTypeId: number): Observable<Boolean> {
    return this.apiService.delete('CabType/deleteCabType', cabTypeId).pipe(
      map((response)=>{
        if(response){
          console.log(response);
          return true;
        }
        return false;
      })
    );
  }

  getCabTypeById(id:number): Observable<CabType> {
    return this.apiService.getById('CabType/', id);
  }
}
