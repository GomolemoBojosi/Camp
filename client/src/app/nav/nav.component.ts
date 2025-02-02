import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  loginForm: FormGroup;

  constructor(public accountService: AccountService,
    private fb: FormBuilder,
    private toastr: ToastrService,
    private router: Router) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm() {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  login() {
    this.accountService.login(this.loginForm.value).subscribe(results => {
      this.toastr.success("successfully logged in");
      this.router.navigateByUrl('/campgrounds');
    }, error => {
      this.toastr.error("invalid username or password");
    });
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/')
  }
}
