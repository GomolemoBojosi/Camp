import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CampgroundsListComponent } from './campgrounds/campgrounds-list/campgrounds-list.component';
import { CampgroundsDetailComponent } from './campgrounds/campgrounds-detail/campgrounds-detail.component';
import { NavComponent } from './nav/nav.component';
import { AddCampgroundComponent } from './campgrounds/add-campground/add-campground.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    CampgroundsListComponent,
    CampgroundsDetailComponent,
    NavComponent,
    AddCampgroundComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
