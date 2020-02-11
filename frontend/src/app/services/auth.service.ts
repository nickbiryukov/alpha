import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ConfigService} from './config.service';
import {LoginModel} from '../pages/auth/models/login-model';
import {Observable} from 'rxjs';
import {TokenModel} from '../pages/auth/models/token-model';
import {catchError, retry} from 'rxjs/operators';
import {ExceptionService} from './exception.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = '';

  constructor(private http: HttpClient, private configService: ConfigService,
              private exceptionService: ExceptionService) {
    this.apiUrl = configService.getApiUrl() + 'accounts/';
  }

  login(loginModel: LoginModel): Observable<TokenModel> {
    return this.http.post<TokenModel>(
      this.apiUrl + 'login', JSON.stringify(loginModel), this.configService.getHttpOptions())
      .pipe(
        retry(1),
        catchError(this.exceptionService.throwError)
      );
  }
}
