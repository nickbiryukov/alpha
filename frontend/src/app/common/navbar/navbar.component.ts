import { Component, OnInit } from '@angular/core';
import {RoleService} from '../../services/role.service';
import {AuthService} from '../../services/auth.service';
import {TokenStorageService} from '../../services/token.storage.service';
import {UserModel} from '../../pages/users/models/user-model';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  private isManager: boolean;
  private currentUser: UserModel;
  private navbarOpen = false;

  constructor(
    private roleService: RoleService,
    private tokenStorageService: TokenStorageService
  ) {
    this.isManager = roleService.IsManager;
    this.currentUser = tokenStorageService.getUser();

    /*if(tokenStorageService.isloggedIn) {

    }*/
  }

  ngOnInit() {
  }

  toggleNavbar() {
    this.navbarOpen = !this.navbarOpen;
  }

  signOut() {
    this.tokenStorageService.signOut();
  }
}
