import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ConfigService} from './config.service';
import {ExceptionService} from './exception.service';
import {Observable} from 'rxjs';
import {catchError, retry} from 'rxjs/operators';
import {RoomModel} from '../pages/rooms/models/room-model';
import {RoomShortModel} from '../pages/rooms/models/room-short-model';
import {RoomWithDetailsModel} from '../pages/rooms/models/room-with-details';

@Injectable({
  providedIn: 'root'
})
export class RoomService {
  apiUrl = '';

  constructor(
    private http: HttpClient,
    private configService: ConfigService,
    private exceptionService: ExceptionService
  ) {
    this.apiUrl = configService.getApiUrl() + 'rooms/';
  }

  getRooms(): Observable<RoomModel[]> {
    return this.http.get<RoomModel[]>(this.apiUrl)
      .pipe(
        retry(1),
        catchError(this.exceptionService.throwError)
      );
  }

  getRoomWithDetails(): Observable<RoomWithDetailsModel[]> {
    return this.http.get<RoomWithDetailsModel[]>(this.apiUrl + 'withDetails')
      .pipe(
        retry(1),
        catchError(this.exceptionService.throwError)
      );
  }

  getRoomWithDetailsById(roomId: string): Observable<RoomWithDetailsModel> {
    return this.http.get<RoomWithDetailsModel>(this.apiUrl + 'withDetails/' + roomId)
      .pipe(
        retry(1),
        catchError(this.exceptionService.throwError)
      );
  }

  getRoom(roomId: string): Observable<RoomModel> {
    return this.http.get<RoomModel>(this.apiUrl + roomId)
      .pipe(
        retry(1),
        catchError(this.exceptionService.throwError)
      );
  }

  addRoom(room: RoomShortModel): Observable<RoomModel> {
    return this.http.post<RoomModel>(
      this.apiUrl, JSON.stringify(room), this.configService.getHttpOptions()
    ).pipe(
      retry(1),
      catchError(this.exceptionService.throwError)
    );
  }

  editRoom(roomId: string, room: RoomShortModel): Observable<RoomModel> {
    return this.http.put<RoomModel>(
      this.apiUrl + roomId, JSON.stringify(room), this.configService.getHttpOptions()
    ).pipe(
      retry(1),
      catchError(this.exceptionService.throwError)
    );
  }

  deleteRoom(userId: string) {
    return this.http.delete(this.apiUrl + userId)
      .pipe(
        retry(1),
        catchError(this.exceptionService.throwError)
      );
  }
}
