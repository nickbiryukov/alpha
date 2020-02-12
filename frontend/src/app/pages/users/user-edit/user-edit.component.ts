import {Component, OnInit} from '@angular/core';
import {UserService} from '../../../services/user.service';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {UserModel} from '../models/user-model';
import {RoleOptions} from '../../auth/models/role-options';
import {ExceptionService} from '../../../services/exception.service';
import {catchError} from 'rxjs/operators';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {
  private actionType: string;

  private userId: string;
  private existingUser: UserModel;

  private form: FormGroup;
  private formLogin: string;
  private formPassword: string;
  private formName: string;
  private formSurname: string;
  private formRole: string;
  private roles;

  constructor(
    private userService: UserService,
    private formBuilder: FormBuilder,
    private avRoute: ActivatedRoute,
    private router: Router,
    private exceptionService: ExceptionService
  ) {
    const idParam = 'id';

    this.actionType = 'Add';
    this.formLogin = 'login';
    this.formPassword = 'password';
    this.formName = 'name';
    this.formSurname = 'surname';
    this.formRole = 'role';

    this.roles = RoleOptions;

    if (this.avRoute.snapshot.params[idParam]) {
      this.userId = this.avRoute.snapshot.params[idParam];
    }

    this.form = this.formBuilder.group({
      userId: '',

      login: ['', [Validators.required]],
      password: ['', [Validators.required]],
      name: ['', [Validators.required]],
      surname: ['', [Validators.required]],
      role: ['', [Validators.required]]
    });
  }

  get login() {
    return this.form.get(this.formLogin);
  }

  get password() {
    return this.form.get(this.formPassword);
  }

  get name() {
    return this.form.get(this.formName);
  }

  get surname() {
    return this.form.get(this.formSurname);
  }

  get role() {
    return this.form.get(this.formRole);
  }

  ngOnInit() {
    if (this.userId) {
      this.actionType = 'Edit';
      this.userService.getUser(this.userId)
        .subscribe(data => (
          this.existingUser = data,
            this.form.controls[this.formLogin].setValue(data.login),
            this.form.controls[this.formName].setValue(data.name),
            this.form.controls[this.formSurname].setValue(data.surname),
            this.form.controls[this.formRole].setValue(data.roleId)
        ));
    }
  }

  save() {
    if (!this.form.valid) {
      return;
    }

    if (this.actionType === 'Add') {
      this.userService.addUser({
        login: this.login.value,
        password: this.password.value,
        name: this.name.value,
        surname: this.surname.value,
        roleId: this.role.value
      }).subscribe(() => {
          this.router.navigate(['user-list']);
        },
        catchError(this.exceptionService.throwError));
    }

    if (this.actionType === 'Edit') {
      this.userService.editUser(this.userId, {
        login: this.login.value,
        password: this.password.value,
        name: this.name.value,
        surname: this.surname.value,
        roleId: this.role.value,
      }).subscribe((data) => {
          this.router.navigate(['user-list']);
        },
        catchError(this.exceptionService.throwError));
    }
  }

  cancel() {
    this.router.navigate(['/user-list']);
  }
}
