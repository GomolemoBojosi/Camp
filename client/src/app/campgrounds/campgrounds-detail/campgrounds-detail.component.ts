import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Campground } from 'src/app/_models/campground';
import { CampgroundService } from 'src/app/_services/campground.service';

@Component({
  selector: 'app-campgrounds-detail',
  templateUrl: './campgrounds-detail.component.html',
  styleUrls: ['./campgrounds-detail.component.css']
})
export class CampgroundsDetailComponent implements OnInit {
  campground: Campground;

  constructor(private campgroundService: CampgroundService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.getCampground();
  }

  getCampground() {
    const id = parseInt(this.route.snapshot.paramMap.get('id'));

    if (id) {
      this.campgroundService.getCampground(id).subscribe(results => {
        this.campground = results;
      }, error => {
        console.log(error);
      })
    }
  };

  onDeleteCampground() {
    const id = parseInt(this.route.snapshot.paramMap.get('id'));

    this.campgroundService.deleteCampground(id).subscribe(results => {
      this.router.navigateByUrl('/campgrounds');
    }, error => {
      console.log(error);
    });
  };

  back() {
    this.router.navigateByUrl('/campgrounds');
  }

}
