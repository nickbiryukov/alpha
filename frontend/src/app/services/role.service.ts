import {Injectable} from '@angular/core';
import {TokenStorageService} from './token.storage.service';
import {UserModel} from '../pages/users/models/user-model';
import {RoleOptions} from '../pages/auth/models/role-options';
import {ExceptionService} from './exception.service';

@Injectable({
  providedIn: 'root'
})
export class RoleService {
  private currentUser: UserModel;

  constructor(
    private tokenStorageService: TokenStorageService,
    private exceptionService: ExceptionService
  ) {
    this.currentUser = tokenStorageService.getUser();
  }

  get IsManager() {
    this.currentUser = this.tokenStorageService.getUser();
    return this.currentUser && this.currentUser.roleId === RoleOptions.OfficeManager;
  }

  get IsEmployee() {
    this.currentUser = this.tokenStorageService.getUser();
    return this.currentUser && this.currentUser.roleId === RoleOptions.Employee;
  }

  getRoleName(roleId: number): string {
    if (roleId !== 1 && roleId !== 2) {
      this.exceptionService.throwError('Invalid roleId');
    }

    return roleId === 1 ? 'Office Manager' : 'Employee';
  }
}
