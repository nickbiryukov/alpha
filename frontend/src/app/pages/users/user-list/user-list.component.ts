import {Component, OnInit} from '@angular/core';
import {Observable, Subscription} from 'rxjs';
import {UserModel} from '../models/user-model';
import {UserService} from '../../../services/user.service';
import {RoleService} from '../../../services/role.service';

@Component({
  selector: 'app-list-user',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  private isManager: boolean;
  private updateSubscription: Subscription;
  users$: Observable<UserModel[]>;

  constructor(
    private userService: UserService,
    private roleService: RoleService
  ) {
    this.isManager = roleService.IsManager;
  }

  ngOnInit() {
    this.loadUsers();
    /*this.updateSubscription = interval(10000)
      .subscribe(() => this.loadUsers());*/
  }

  loadUsers() {
    this.users$ = this.userService.getUsers();
  }

  delete(userId: string) {
    const ans = confirm('Do you want to delete blog post with id: ' + userId);
    if (ans) {
      this.userService.deleteUser(userId).subscribe(() => this.loadUsers());
    }
  }
}
