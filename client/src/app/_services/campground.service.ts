import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Campground } from '../_models/campground';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user'))?.token
  })
}

@Injectable({
  providedIn: 'root'
})
export class CampgroundService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCamprounds() {
    return this.http.get<Campground[]>(this.baseUrl + 'campgrounds');
  }

  getCampground(id: number) {
    return this.http.get<Campground>(this.baseUrl + 'campgrounds/' + id);
  }

  addCampground(campground: Campground): Observable<Campground> {
    return this.http.post<Campground>(this.baseUrl + 'campgrounds/new', campground);
  }

  deleteCampground(id: number): Observable<Campground> {
    return this.http.delete<Campground>(this.baseUrl + 'campgrounds/' + id);
  }

  updateCampground(campground: Campground): Observable<Campground> {
    return this.http.put<Campground>(this.baseUrl + 'campgrounds', campground);
  }
}
