import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Campground } from '../_models/campground';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CampgroundService {
  baseUrl = 'https://localhost:7283/api/';

  constructor(private http: HttpClient) { }

  getCamprounds(): Observable<Campground[]> {
    return this.http.get<Campground[]>(this.baseUrl + 'campgrounds');
  }

  getCampground(id: number): Observable<Campground> {
    return this.http.get<Campground>(this.baseUrl + 'campgrounds/' + id);
  }

  addCampground(campground: Campground): Observable<Campground> {
    return this.http.post<Campground>(this.baseUrl + 'campgrounds/new', campground);
  }
}
