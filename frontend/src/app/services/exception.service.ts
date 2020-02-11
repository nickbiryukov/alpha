import {Injectable} from '@angular/core';
import {throwError} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ExceptionService {

  constructor() { }

  throwError(error) {
    let errorMessage: string;
    if (error.error instanceof ErrorEvent) {
      errorMessage = `Error: ${error.error.message}`;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    /*window.alert(errorMessage);*/
    return throwError(errorMessage);
  }
}
