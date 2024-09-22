import { Component, Input, OnInit } from '@angular/core';
import { Campground } from 'src/app/_models/campground';
import { CampgroundService } from 'src/app/_services/campground.service';

@Component({
  selector: 'app-add-campground',
  templateUrl: './add-campground.component.html',
  styleUrls: ['./add-campground.component.css']
})
export class AddCampgroundComponent implements OnInit {
  campground: Campground = {
    id: 0,
    description: '',
    location: '',
    price: '',
    title: ''
  };

  constructor(private campgroundService: CampgroundService) { }

  ngOnInit(): void {
  }

  addCampground() {
    this.campgroundService.addCampground(this.campground).subscribe(results => {
      console.log(results);
    }, error => {
      console.log(error);
    })
  }

  cancel() {
    console.log("Cancelled");
  }
}
