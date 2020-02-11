import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ConfigService} from './config.service';
import {ExceptionService} from './exception.service';
import {Observable} from 'rxjs';
import {UserModel} from '../pages/users/models/user-model';
import {catchError, retry} from 'rxjs/operators';
import {UserAddModel} from '../pages/users/models/user-add-model';
import {UserShortModel} from '../pages/users/models/user-short-model';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {
  apiUrl = '';

  constructor(
    private http: HttpClient,
    private configService: ConfigService,
    private exceptionService: ExceptionService
  ) {
    this.apiUrl = configService.getApiUrl() + 'reservation/';
  }

  getReservations(): Observable<UserModel[]> {
    return this.http.get<UserModel[]>(this.apiUrl)
      .pipe(
        retry(1),
        catchError(this.exceptionService.throwError)
      );
  }

  getReservation(userId: string): Observable<UserModel> {
    return this.http.get<UserModel>(this.apiUrl + userId)
      .pipe(
        retry(1),
        catchError(this.exceptionService.throwError)
      );
  }

  addReservation(user: UserAddModel): Observable<UserModel> {
    return this.http.post<UserModel>(
      this.apiUrl, JSON.stringify(user), this.configService.getHttpOptions()
    ).pipe(
      retry(1),
      catchError(this.exceptionService.throwError)
    );
  }

  editReservation(userId: string, user: UserShortModel): Observable<UserModel> {
    return this.http.put<UserModel>(
      this.apiUrl + userId, JSON.stringify(user), this.configService.getHttpOptions()
    ).pipe(
      retry(1),
      catchError(this.exceptionService.throwError)
    );
  }

  deleteReservation(userId: string) {
    return this.http.delete(this.apiUrl + userId)
      .pipe(
        retry(1),
        catchError(this.exceptionService.throwError)
      );
  }
}
