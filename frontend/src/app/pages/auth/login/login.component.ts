import {Component, OnInit} from '@angular/core';
import {AuthService} from 'src/app/services/auth.service';
import {TokenStorageService} from 'src/app/services/token.storage.service';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {UserService} from '../../../services/user.service';
import {ActivatedRoute, Router} from '@angular/router';
import {ExceptionService} from '../../../services/exception.service';
import {catchError} from 'rxjs/operators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  submitted = false;
  returnUrl: string;
  error = '';

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private route: ActivatedRoute,
    private router: Router,
    private tokenStorageService: TokenStorageService,
    private userService: UserService,
    private exceptionService: ExceptionService
  ) {
    if (this.tokenStorageService.isloggedIn) {
      this.router.navigate(['/']);
    }
  }

  get fm() {
    return this.loginForm.controls;
  }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });

    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';
  }

  onSubmit() {
    this.submitted = true;
    if (this.loginForm.invalid) {
      return;
    }

    this.authService.login({
      login: this.fm.username.value,
      password: this.fm.password.value
    }).subscribe(a => {
        this.tokenStorageService.saveToken(a.value);

        this.userService.getUserByLogin(this.fm.username.value)
          .subscribe(b => {
              this.tokenStorageService.saveUser(b);
              this.authService.getLoggedInSource.next(true);
              this.router.navigate([this.returnUrl]);
            },
            catchError(this.exceptionService.throwError)
          );
      },
      catchError(this.exceptionService.throwError)
    );
  }
}
