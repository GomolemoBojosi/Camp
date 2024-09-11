import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'client';
  cities: any;
  campgrounds: any;
  users: any;

  constructor(private http: HttpClient) {

  }

  ngOnInit() {
    this.getCampgrounds();
  }

  getCities() {
    this.http.get('https://localhost:7283/api/cities').subscribe(results => {
      this.cities = results;
    }, error => {
      console.log(error);
    });
  }

  getCampgrounds() {
    this.http.get('https://localhost:7283/api/campgrounds').subscribe(results => {
      this.campgrounds = results;
    }, error => {
      console.log(error);
    });
  }
}
