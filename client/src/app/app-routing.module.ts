import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CampgroundsListComponent } from './campgrounds/campgrounds-list/campgrounds-list.component';
import { CampgroundsDetailComponent } from './campgrounds/campgrounds-detail/campgrounds-detail.component';
import { AddCampgroundComponent } from './campgrounds/add-campground/add-campground.component';
import { HomeComponent } from './home/home.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'campgrounds', component: CampgroundsListComponent },
  { path: 'campgrounds/new', component: AddCampgroundComponent },
  { path: 'campgrounds/:id', component: CampgroundsDetailComponent },
  { path: 'errors', component: TestErrorsComponent },
  { path: 'not-found', component: NotFoundComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
