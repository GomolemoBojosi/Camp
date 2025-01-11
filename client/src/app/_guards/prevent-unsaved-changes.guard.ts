import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanDeactivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { CampgroundEditComponent } from '../campgrounds/campground-edit/campground-edit.component';

@Injectable({
  providedIn: 'root'
})
export class PreventUnsavedChangesGuard implements CanDeactivate<unknown> {
  canDeactivate(component: CampgroundEditComponent): boolean {
    if (component.editCampForm.dirty) {
      return confirm('Are you sure you want to continue? Any unsaved changes will be lost');
    }

    return true;
  }

}
