import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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
    title: '',
    image: ''
  };

  constructor(private campgroundService: CampgroundService, private router: Router) { }

  ngOnInit(): void {
  }

  addCampground() {
    this.campgroundService.addCampground(this.campground).subscribe(results => {
      this.router.navigateByUrl(`/campgrounds/${results.id}`);
    }, error => {
      console.log(error);
    })
  }

  getCampground(id: number) {
    this.campgroundService.getCampground(id).subscribe(results => {

    }, error => {
      console.log(error);
    })
  };

  cancel() {
    this.router.navigateByUrl('/campgrounds');
  }
}
