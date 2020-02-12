import {Injectable} from '@angular/core';
import {throwError} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ExceptionService {

  constructor() {
  }

  throwError(error: any) {
    const errorMessage = `Error: ${error.error.error}`;

    window.alert(errorMessage);
    return throwError(errorMessage);
  }
}
