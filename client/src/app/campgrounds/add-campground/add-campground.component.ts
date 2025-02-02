import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/_models/User';
import { CampgroundService } from 'src/app/_services/campground.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-add-campground',
  templateUrl: './add-campground.component.html',
  styleUrls: ['./add-campground.component.css']
})
export class AddCampgroundComponent implements OnInit {
  addCampgroundForm: FormGroup;
  user: User;

  constructor(
    private campgroundService: CampgroundService,
    private router: Router,
    private toastr: ToastrService,
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.createForm()
  }

  createForm() {
    this.addCampgroundForm = this.fb.group({
      title: ['', Validators.required],
      location: ['', Validators.required],
      image: ['', Validators.required],
      price: ['', Validators.required],
      description: ['', Validators.required]
    });
  }

  addCampground() {
    const user = JSON.parse(localStorage.getItem('user'));
    const campData = {
      ...this.addCampgroundForm.value,
      userId: user.id
    }

    this.campgroundService.addCampground(campData).subscribe(results => {
      console.log(results);
      this.toastr.success("camp site successfully added");
      this.router.navigateByUrl(`/campgrounds/${results.id}`);
    }, error => {
      this.toastr.error("Error occured while adding camp site");
    })
  }

  getCampground(id: number) {
    this.campgroundService.getCampground(id).subscribe(results => { },
      error => {
        this.toastr.success("error occured while fetching camp site");
      });
  };

  cancel() {
    this.router.navigateByUrl('/campgrounds');
  }
}
