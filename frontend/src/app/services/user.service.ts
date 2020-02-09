import { Injectable } from '@angular/core';
import {catchError, retry} from 'rxjs/operators';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {ConfigService} from './config.service';
import {Observable, throwError} from 'rxjs';
import {UserModel} from '../pages/users/models/user-model';
import {AddUserModel} from '../pages/users/models/add-user-model';
import {UserShortModel} from '../pages/users/models/user-short-model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  apiUrl = '';
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(private http: HttpClient, private configService: ConfigService) {
    this.apiUrl = configService.getApiUrl() + 'users/';
  }

  getUsers(): Observable<UserModel[]> {
    return this.http.get<UserModel[]>(this.apiUrl)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  getUser(userId: string): Observable<UserModel> {
    return this.http.get<UserModel>(this.apiUrl + userId)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  addUser(user: AddUserModel): Observable<UserModel> {
    return this.http.post<UserModel>(this.apiUrl, JSON.stringify(user), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  editUser(user: UserShortModel): Observable<UserModel> {
    return this.http.put<UserModel>(this.apiUrl, JSON.stringify(user), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  deleteUser(userId: string) {
    console.log(this.apiUrl + userId);
    this.http.delete(this.apiUrl + userId)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
