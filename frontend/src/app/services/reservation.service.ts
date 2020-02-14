import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ConfigService} from './config.service';
import {ExceptionService} from './exception.service';
import {Observable} from 'rxjs';
import {catchError, retry} from 'rxjs/operators';
import {ReservationModel} from '../pages/reservations/models/reservation-model';
import {ReservationAddModel} from '../pages/reservations/models/reservation-add-model';

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
    this.apiUrl = configService.getApiUrl() + 'reservations/';
  }

  getReservations(): Observable<ReservationModel[]> {
    return this.http.get<ReservationModel[]>(this.apiUrl)
      .pipe(
        retry(1),
        catchError(this.exceptionService.throwError)
      );
  }

  getReservation(reservationId: string): Observable<ReservationModel> {
    return this.http.get<ReservationModel>(this.apiUrl + reservationId)
      .pipe(
        retry(1),
        catchError(this.exceptionService.throwError)
      );
  }

  addReservation(reservation: ReservationAddModel): Observable<ReservationModel> {
    return this.http.post<ReservationModel>(
      this.apiUrl, JSON.stringify(reservation), this.configService.getHttpOptions()
    ).pipe(
      retry(1),
      catchError(this.exceptionService.throwError)
    );
  }

  editConfirmationReservation(reservationId: string, confirmation: boolean): Observable<ReservationModel> {
    return this.http.put<ReservationModel>(
      this.apiUrl + 'updateConfirmation/' + reservationId, confirmation, this.configService.getHttpOptions()
    ).pipe(
      retry(1),
      catchError(this.exceptionService.throwError)
    );
  }

  deleteReservation(reservationId: string) {
    return this.http.delete(this.apiUrl + reservationId)
      .pipe(
        retry(1),
        catchError(this.exceptionService.throwError)
      );
  }
}
