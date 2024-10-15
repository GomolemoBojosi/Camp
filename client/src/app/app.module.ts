import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CampgroundsListComponent } from './campgrounds/campgrounds-list/campgrounds-list.component';
import { CampgroundsDetailComponent } from './campgrounds/campgrounds-detail/campgrounds-detail.component';
import { NavComponent } from './nav/nav.component';
import { AddCampgroundComponent } from './campgrounds/add-campground/add-campground.component';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { CampgroundCardsComponent } from './campgrounds/campground-cards/campground-cards.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';

@NgModule({
  declarations: [
    AppComponent,
    CampgroundsListComponent,
    CampgroundsDetailComponent,
    NavComponent,
    AddCampgroundComponent,
    HomeComponent,
    CampgroundCardsComponent,
    TestErrorsComponent,
    NotFoundComponent,
    ServerErrorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
