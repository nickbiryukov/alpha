import { Component, OnInit } from '@angular/core';
import {Observable} from 'rxjs';
import {UserModel} from '../models/user-model';
import {UserService} from '../../../services/user.service';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-detail-user',
  templateUrl: './detail-user.component.html',
  styleUrls: ['./detail-user.component.css']
})
export class DetailUserComponent implements OnInit {

  user$: Observable<UserModel>;
  userId: string;

  constructor(private userService: UserService, private activatedRoute: ActivatedRoute) {
    const idParam = 'id';
    if (this.activatedRoute.snapshot.params[idParam]) {
      this.userId = this.activatedRoute.snapshot.params[idParam];
    }
  }

  ngOnInit() {
    this.loadUser();
  }

  loadUser() {
    this.user$ = this.userService.getUser(this.userId);
  }
}
