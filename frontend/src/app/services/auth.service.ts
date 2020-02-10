import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { ConfigService } from './config.service';
import { LoginModel } from '../pages/auth/models/login-model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = '';

  constructor(private http: HttpClient, private configService: ConfigService) {
    this.apiUrl = configService.getApiUrl() + 'accounts/';
  }

  login(credentials): Observable<any> {
    return this.http.post(this.apiUrl + 'login', {
      username: credentials.username,
      password: credentials.password
    }, this.configService.getHttpOptions());
  }
}
