import {Component, OnInit} from '@angular/core';
import {interval, Observable, Subscription} from 'rxjs';
import {UserModel} from '../models/user-model';
import {UserService} from '../../../services/user.service';
import {RoleService} from '../../../services/role.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  private isManager: boolean;
  private updateSubscription: Subscription;
  private users: Observable<UserModel[]>;

  constructor(
    private userService: UserService,
    private roleService: RoleService
  ) {
    this.isManager = roleService.IsManager;
  }

  ngOnInit() {
    this.loadUsers();
    this.updateSubscription = interval(10000)
      .subscribe(() => this.loadUsers());
  }

  loadUsers() {
    this.users = this.userService.getUsers();
  }

  getRoleName(roleId: number): string {
    return this.roleService.getRoleName(roleId);
  }

  delete(userId: string, login: string) {
    const ans = confirm('Do you want to delete user? ' + login);
    if (ans) {
      this.userService.deleteUser(userId)
        .subscribe(() => this.loadUsers());
    }
  }
}
