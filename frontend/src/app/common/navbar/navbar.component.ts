import {Component, OnInit} from '@angular/core';
import {RoleService} from '../../services/role.service';
import {TokenStorageService} from '../../services/token.storage.service';
import {UserModel} from '../../pages/users/models/user-model';
import {AuthService} from '../../services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  private currentUser = {login: ''};
  private navbarOpen = false;
  private isloggedIn: boolean;

  constructor(
    private roleService: RoleService,
    private tokenStorageService: TokenStorageService,
    private authService: AuthService
  ) {
    this.currentUser = this.tokenStorageService.getUser();
    this.isloggedIn = this.tokenStorageService.isloggedIn;

    this.authService.getLoggedInSource.subscribe(hasAuth => {
      this.currentUser = tokenStorageService.getUser();
      this.isloggedIn = hasAuth;
    });
  }

  toggleNavbar() {
    this.navbarOpen = !this.navbarOpen;
  }

  signOut() {
    this.authService.signOut();
  }

  ngOnInit(): void {
  }
}
