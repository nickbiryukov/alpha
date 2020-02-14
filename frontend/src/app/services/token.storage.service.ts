import {Injectable} from '@angular/core';
import {UserModel} from '../pages/users/models/user-model';

const TOKEN_KEY = 'auth-token';
const USER_KEY = 'auth-user';

@Injectable({
  providedIn: 'root'
})
export class TokenStorageService {

  constructor() {
  }

  public get isloggedIn(): boolean {
    return TokenStorageService.hasToken() && TokenStorageService.hasUser();
  }

  private static hasToken(): boolean {
    return !!localStorage.getItem(TOKEN_KEY);
  }

  private static hasUser(): boolean {
    return !!localStorage.getItem(USER_KEY);
  }

  public saveToken(token: string) {
    localStorage.removeItem(TOKEN_KEY);
    localStorage.setItem(TOKEN_KEY, token);
  }

  public getToken(): string {
    return localStorage.getItem(TOKEN_KEY);
  }

  public saveUser(user: UserModel) {
    localStorage.removeItem(USER_KEY);
    localStorage.setItem(USER_KEY, JSON.stringify(user));
  }

  public getUser(): UserModel {
    return JSON.parse(localStorage.getItem(USER_KEY));
  }

  public signOut() {
    localStorage.clear();
  }
}
