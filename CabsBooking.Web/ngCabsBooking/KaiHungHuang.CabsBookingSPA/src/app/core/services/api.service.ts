import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private headers: HttpHeaders;
  constructor(protected http: HttpClient) { 
    this.headers = new HttpHeaders();
    this.headers.append('Content-type', 'application/json');
  }

  getAll(path:string, id?:number): Observable<any[]> {
    let Url: string;
    if(id){
      Url = `${environment.apiUrl}${path}` + '/' + id;
    }
    else
      Url = `${environment.apiUrl}${path}`;

    return this.http.get(Url)
    .pipe(map((response)=>response as any[]))
  }

  create(path:string, resource: any): Observable<any>{
    return this.http.post(`${environment.apiUrl}${path}`, resource, {headers: this.headers})
    .pipe(map(response=>response));
  }

  update(path:string, resource: any): Observable<any>{
    return this.http.put(`${environment.apiUrl}${path}`, resource, {headers: this.headers})
    .pipe(map(response=>response));
  }

  delete(path:string, id: number): Observable<any>{
    return this.http.delete(`${environment.apiUrl}${path}`+'?id='+id, {headers: this.headers})
    .pipe(map((response)=>response));
  }

  getById(path:string, id:number): Observable<any>{
    return this.http.get(`${environment.apiUrl}${path}`+id)
    .pipe(map((response)=>response as any));
  }
}
