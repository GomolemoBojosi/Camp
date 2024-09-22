import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CampgroundsListComponent } from './campgrounds/campgrounds-list/campgrounds-list.component';
import { CampgroundsDetailComponent } from './campgrounds/campgrounds-detail/campgrounds-detail.component';
import { AddCampgroundComponent } from './campgrounds/add-campground/add-campground.component';

const routes: Routes = [
  { path: '', component: CampgroundsListComponent },
  { path: 'campgrounds', component: CampgroundsListComponent },
  { path: 'campgrounds/new', component: AddCampgroundComponent },
  { path: 'campgrounds/:id', component: CampgroundsDetailComponent },
  { path: '**', component: CampgroundsListComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
