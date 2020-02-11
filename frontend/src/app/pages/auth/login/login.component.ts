import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { TokenStorageService } from 'src/app/services/token.storage.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import {LoginModel} from '../models/login-model';
import {noop} from 'rxjs';
import {UserService} from '../../../services/user.service';
import {RoleService} from '../../../services/role.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';
  isManager: boolean;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private tokenStorageService: TokenStorageService,
    private userService: UserService
  ) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  get f() { return this.loginForm.controls; }

  onSubmit() {
    this.submitted = true;

    this.authService.login({
      login: this.f.username.value,
      password: this.f.password.value
    }).subscribe(a => {
        this.tokenStorageService.saveToken(a.value);
        this.userService.getUserByLogin(this.f.username.value)
          .subscribe(b => {
          this.tokenStorageService.saveUser(b);
        });
    });

    if (this.loginForm.invalid) {
      return;
    }

    this.loading = true;
  }

  reloadPage() {
    window.location.reload();
  }
}
