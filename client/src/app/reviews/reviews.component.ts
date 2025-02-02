import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Review } from '../_models/review';
import { ReviewsService } from '../_services/reviews.service';
import { Campground } from '../_models/campground';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from '../_models/User';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.css']
})
export class ReviewsComponent implements OnInit {
  baseUrl = environment.apiUrl;
  addReviewForm: FormGroup;
  reviews: Review[] = [];
  campground: Campground;
  currentUser: User;
  author: User;

  @Input() filteredReviews: Review[] = [];
  @Output() reviewsLoaded = new EventEmitter<Review[]>();

  constructor(
    private reviewService: ReviewsService,
    private userService: UserService,
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.createForm();
    this.getReviews();
  }

  createForm() {
    this.addReviewForm = this.fb.group({
      body: ['', Validators.required],
      rating: ['', Validators.required]
    });
  }

  getReviews() {
    this.reviewService.getReviews().subscribe(results => {
      this.reviews = results;
      this.reviews.forEach(r => {
        this.getUser(r);
      })
      this.reviewsLoaded.emit(results);
    }, error => {
      this.toastr.error(error);
    })
  }

  getUser(review: Review) {
    this.userService.getUser(review.id).subscribe(results => {
      this.author = results;
    })
  }

  createReview() {
    const id = parseInt(this.route.snapshot.paramMap.get('id'));
    const user = JSON.parse(localStorage.getItem('user')) as User;
    const reviewData: Review = {
      ...this.addReviewForm.value as Review,
      userId: user.id,
      campgroundId: id
    };

    this.reviewService.createReview(reviewData).subscribe(results => {
      this.toastr.success("review successfully created");
      this.getReviews();
    }, error => {
      this.toastr.error("error occured while creating a review");
    })
  }

  reset() {

  }
}
