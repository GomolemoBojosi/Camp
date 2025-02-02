import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CampgroundsListComponent } from './campgrounds/campgrounds-list/campgrounds-list.component';
import { CampgroundsDetailComponent } from './campgrounds/campgrounds-detail/campgrounds-detail.component';
import { AddCampgroundComponent } from './campgrounds/add-campground/add-campground.component';
import { HomeComponent } from './home/home.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { CampgroundEditComponent } from './campgrounds/campground-edit/campground-edit.component';
import { PreventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'campgrounds', component: CampgroundsListComponent, canActivate: [AuthGuard] },
      { path: 'campground/new', component: AddCampgroundComponent },
      { path: 'campgrounds/:id', component: CampgroundsDetailComponent },
      {
        path: 'campground/edit/:id', component: CampgroundEditComponent,
        canDeactivate: [PreventUnsavedChangesGuard]
      },
    ]
  },
  { path: 'errors', component: TestErrorsComponent },
  { path: 'not-found', component: NotFoundComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
