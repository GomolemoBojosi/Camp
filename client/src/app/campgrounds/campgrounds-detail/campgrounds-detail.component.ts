import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Campground } from 'src/app/_models/campground';
import { Review } from 'src/app/_models/review';
import { CampgroundService } from 'src/app/_services/campground.service';

@Component({
  selector: 'app-campgrounds-detail',
  templateUrl: './campgrounds-detail.component.html',
  styleUrls: ['./campgrounds-detail.component.css']
})
export class CampgroundsDetailComponent implements OnInit {
  filteredReviews: Review[] = [];
  campground: Campground;
  @Input() filteredReviewsSent: Review[];
  @Output() selectedCampground = new EventEmitter<Campground>();

  constructor(
    private toastr: ToastrService,
    private campgroundService: CampgroundService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.getCampground();
  }

  getCampground() {
    const id = parseInt(this.route.snapshot.paramMap.get('id'));

    if (id) {
      this.campgroundService.getCampground(id).subscribe(results => {
        this.campground = results;
      }, error => {
        this.toastr.error(error);
      })
    }
  };

  onDeleteCampground() {
    const id = parseInt(this.route.snapshot.paramMap.get('id'));

    this.campgroundService.deleteCampground(id).subscribe(results => {
      this.toastr.success("camp successfully deleted");

      this.router.navigateByUrl('/campgrounds');
    }, error => {
      this.toastr.error("error occured while deleting a camp site");
    });
  };

  onEditCampground() {
    const id = parseInt(this.route.snapshot.paramMap.get('id'));
    this.selectedCampground.emit(this.campground);
    this.router.navigate(['/campground/edit', id]);
  }

  handleReviews(reviews: Review[]) {
    const id = parseInt(this.route.snapshot.paramMap.get('id'));
    this.filteredReviews = reviews.filter(review => review.campgroundId === id);
    this.filteredReviewsSent = this.filteredReviews;
  }

  back() {
    this.router.navigateByUrl('/campgrounds');
  }
}
