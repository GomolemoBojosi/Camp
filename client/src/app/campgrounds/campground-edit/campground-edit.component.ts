import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Campground } from 'src/app/_models/campground';
import { CampgroundService } from 'src/app/_services/campground.service';

@Component({
  selector: 'app-campground-edit',
  templateUrl: './campground-edit.component.html',
  styleUrls: ['./campground-edit.component.css']
})
export class CampgroundEditComponent implements OnInit {
  editCampForm: FormGroup;
  campground: Campground;

  @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any) {
    if (this.editCampForm.dirty) {
      $event.return = true;
    };
  }

  constructor(
    private campgroundService: CampgroundService,
    private router: ActivatedRoute,
    private toastr: ToastrService,
    private route: Router,
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.getCampground();
    this.createForm();
  }

  createForm() {
    this.editCampForm = this.fb.group({
      title: ['', Validators.required],
      location: ['', Validators.required],
      image: ['', Validators.required],
      price: ['', Validators.required],
      description: ['', Validators.required],
    })
  }

  populateForm() {
    if (this.campground) {
      this.editCampForm.patchValue({
        title: this.campground.title,
        location: this.campground.location,
        image: this.campground.image,
        price: this.campground.price,
        description: this.campground.description,
      });
    }
  }

  getCampground() {
    const id = parseInt(this.router.snapshot.paramMap.get("id"));
    this.campgroundService.getCampground(id).subscribe(results => {
      this.campground = results;
      this.populateForm();
    })
  }

  updateCampground() {
    const id = parseInt(this.router.snapshot.paramMap.get("id"));
    if (this.editCampForm.valid) {
      const updatedCampground = {
        ...this.campground,
        ...this.editCampForm.value
      };

      this.campgroundService.updateCampground({ ...updatedCampground, id }).subscribe(results => {
        this.toastr.success('Campground updated successfully');
        this.editCampForm.reset(updatedCampground);
      }, error => {
        this.toastr.error(error);
      });
    }
  }

  back() {
    this.route.navigateByUrl("/campgrounds");
  }
}
