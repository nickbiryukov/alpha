import { Component, OnInit } from '@angular/core';
import {interval, Observable, Subscription, timer} from 'rxjs';
import {UserModel} from '../models/user-model';
import {UserService} from '../../../services/user.service';

@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.css']
})
export class ListUserComponent implements OnInit {

  private updateSubscription: Subscription;
  users$: Observable<UserModel[]>;

  constructor(private userService: UserService) { }

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
