import {Component, OnInit} from '@angular/core';
import {RoleService} from '../../services/role.service';
import {TokenStorageService} from '../../services/token.storage.service';
import {AuthService} from '../../services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  private currentUser = {login: '', name: '', surname: ''};
  private navbarOpen = false;
  private isloggedIn: boolean;
  private isManager: boolean;

  constructor(
    private roleService: RoleService,
    private tokenStorageService: TokenStorageService,
    private authService: AuthService
  ) {
    this.isloggedIn = this.tokenStorageService.isloggedIn;
    this.isManager = this.roleService.IsManager;
    this.currentUser = this.tokenStorageService.getUser();

    this.authService.getLoggedInSource
      .subscribe(hasAuth => {
        this.currentUser = tokenStorageService.getUser();
        this.isloggedIn = hasAuth;
        this.isManager = this.roleService.IsManager;
      });
  }

  toggleNavbar() {
    this.navbarOpen = !this.navbarOpen;
  }

  signOut() {
    const ans = confirm('Do you want sign out?');
    if (ans) {
      this.authService.signOut();
    }
  }

  ngOnInit(): void {
  }
}
