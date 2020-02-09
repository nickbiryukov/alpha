import { Component, OnInit } from '@angular/core';
import {Observable} from 'rxjs';
import {UserModel} from '../models/user-model';
import {UserService} from '../../../services/user.service';

@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.css']
})
export class ListUserComponent implements OnInit {

  users$: Observable<UserModel[]>;

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.loadUsers();
  }

  loadUsers() {
    this.users$ = this.userService.getUsers();
  }

  delete(userId) {
    this.userService.deleteUser(userId);
    const ans = confirm('Do you want to delete blog post with id: ' + userId);
    if (ans) {
      console.log(userId);
      this.userService.deleteUser(userId);
      /*this.loadUsers();*/
    }
  }

}
