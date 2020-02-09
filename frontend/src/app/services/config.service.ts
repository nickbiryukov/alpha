import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {

  private apiUrl = '';

  constructor() {
    this.apiUrl = 'http://localhost:5000/api/';
  }

  getApiUrl() {
    return this.apiUrl;
  }
}
