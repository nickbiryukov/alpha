import {Component} from '@angular/core';
import {TokenStorageService} from './services/token.storage.service';
import {RoleService} from './services/role.service';
import {AuthService} from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'frontend';
  private isLoggedIn = false;
  private isManager = this.checkIsManager();

  constructor(
    private authService: AuthService,
    private tokenStorageService: TokenStorageService,
    private roleService: RoleService
  ) {
    this.isManager = this.checkIsManager();
  }

  checkIsManager() {
    return this.roleService.IsManager;
  }
}
