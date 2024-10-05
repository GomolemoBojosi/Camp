import { Component, Input, OnInit } from '@angular/core';
import { Campground } from 'src/app/_models/campground';
import { CampgroundService } from 'src/app/_services/campground.service';

@Component({
  selector: 'app-campground-cards',
  templateUrl: './campground-cards.component.html',
  styleUrls: ['./campground-cards.component.css']
})
export class CampgroundCardsComponent implements OnInit {
  @Input() campground: Campground;

  constructor(private campgroundService: CampgroundService) { }

  ngOnInit(): void {
  }

}
