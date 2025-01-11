import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Review } from '../_models/review';

@Injectable({
  providedIn: 'root'
})
export class ReviewsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getReviews(): Observable<Review[]> {
    return this.http.get<Review[]>(this.baseUrl + 'review');
  }

  createReview(review: Review): Observable<Review> {
    return this.http.post<Review>(`${this.baseUrl}review/add-review`, review);
  }
}
