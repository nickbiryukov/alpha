import {Injectable} from '@angular/core';
import {HttpHeaders} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {

  private apiUrl = '';
  private httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  };

  constructor() {
    this.apiUrl = 'https://localhost:5001/api/';
  }

  getApiUrl() {
    return this.apiUrl;
  }

  getHttpOptions() {
    return this.httpOptions;
  }
}
