import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Review } from '../_models/review';
import { ReviewsService } from '../_services/reviews.service';
import { Campground } from '../_models/campground';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.css']
})
export class ReviewsComponent implements OnInit {
  baseUrl = environment.apiUrl;
  reviews: Review[] = [];
  campground: Campground;
  //to do, add form builder class
  review: Review = {
    id: 0,
    body: '',
    campgroundId: 0,
    rating: 0
  }

  @Input() filteredReviews: Review[] = [];
  @Output() reviewsLoaded = new EventEmitter<Review[]>();

  constructor(
    private reviewService: ReviewsService,
    private route: ActivatedRoute,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.getReviews();
  }

  getReviews() {
    this.reviewService.getReviews().subscribe(results => {
      this.reviews = results;
      this.reviewsLoaded.emit(results);
    }, error => {
      this.toastr.error(error);
    })
  }

  createReview() {
    const id = parseInt(this.route.snapshot.paramMap.get('id'));

    this.reviewService.createReview({ ...this.review, campgroundId: id }).subscribe(results => {
      this.toastr.success("review successfully created");
      this.getReviews();
    }, error => {
      this.toastr.error("error occured while creating a review");
    })
  }
}
