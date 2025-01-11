import { Component, OnInit } from '@angular/core';
import { Campground } from 'src/app/_models/campground';
import { CampgroundService } from 'src/app/_services/campground.service';

@Component({
  selector: 'app-campgrounds-list',
  templateUrl: './campgrounds-list.component.html',
  styleUrls: ['./campgrounds-list.component.css']
})
export class CampgroundsListComponent implements OnInit {
  campgrounds: Campground[] = [];
  isLoading = true;
  placeholders = Array(8);

  constructor(private campgroundService: CampgroundService) { }

  ngOnInit(): void {
    this.getCampgrounds();
  }

  getCampgrounds() {
    this.campgroundService.getCamprounds().subscribe(results => {
      this.campgrounds = results;
      this.isLoading = false;
    }, error => {
      console.log(error);
      this.isLoading = false;
    })
  }
}
