import { Injectable } from '@angular/core';
import {catchError, retry} from 'rxjs/operators';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {ConfigService} from './config.service';
import {Observable, throwError} from 'rxjs';
import {UserModel} from '../pages/users/models/user-model';
import {AddUserModel} from '../pages/users/models/add-user-model';
import {UserShortModel} from '../pages/users/models/user-short-model';
import {ExceptionService} from './exception.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  apiUrl = '';

  constructor(private http: HttpClient, private configService: ConfigService, private exceptionService: ExceptionService) {
    this.apiUrl = configService.getApiUrl() + 'users/';
  }

  getUsers(): Observable<UserModel[]> {
    return this.http.get<UserModel[]>(this.apiUrl)
      .pipe(
        retry(1),
        catchError(this.exceptionService.throwError)
      );
  }

  getUser(userId: string): Observable<UserModel> {
    return this.http.get<UserModel>(this.apiUrl + userId)
      .pipe(
        retry(1),
        catchError(this.exceptionService.throwError)
      );
  }

  addUser(user: AddUserModel): Observable<UserModel> {
    return this.http.post<UserModel>(this.apiUrl, JSON.stringify(user), this.configService.getHttpOptions())
      .pipe(
        retry(1),
        catchError(this.exceptionService.throwError)
      );
  }

  editUser(user: UserShortModel): Observable<UserModel> {
    return this.http.put<UserModel>(this.apiUrl, JSON.stringify(user), this.configService.getHttpOptions())
      .pipe(
        retry(1),
        catchError(this.exceptionService.throwError)
      );
  }

  deleteUser(userId: string) {
    return this.http.delete(this.apiUrl + userId)
      .pipe(
        retry(1),
        catchError(this.exceptionService.throwError)
      );
  }
}
