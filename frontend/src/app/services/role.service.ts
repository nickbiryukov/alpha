import { Injectable } from '@angular/core';
import {TokenStorageService} from './token.storage.service';
import {UserModel} from '../pages/users/models/user-model';
import {RoleOptions} from '../pages/auth/models/role-options';

@Injectable({
  providedIn: 'root'
})
export class RoleService {
  private currentUser: UserModel;

  constructor(private tokenStorageService: TokenStorageService) {
    this.currentUser = tokenStorageService.getUser();
  }

  get IsManager() {
    return this.currentUser && this.currentUser.role === RoleOptions.OfficeManager;
  }

  get IsEmployee() {
    return this.currentUser && this.currentUser.role === RoleOptions.Employee;
  }
}
