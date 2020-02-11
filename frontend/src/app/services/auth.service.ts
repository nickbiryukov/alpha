import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ConfigService} from './config.service';
import {LoginModel} from '../pages/auth/models/login-model';
import {Observable, Subject} from 'rxjs';
import {TokenModel} from '../pages/auth/models/token-model';
import {catchError, retry} from 'rxjs/operators';
import {ExceptionService} from './exception.service';
import {TokenStorageService} from './token.storage.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = '';
  private loggedInSource = new Subject<boolean>();

  constructor(
    private http: HttpClient,
    private configService: ConfigService,
    private exceptionService: ExceptionService,
    private tokenStorageService: TokenStorageService
  ) {
    this.apiUrl = configService.getApiUrl() + 'accounts/';
    this.loggedInSource.next(tokenStorageService.isloggedIn);
  }

  get getLoggedInSource(): Subject<boolean> {
    return this.loggedInSource;
  }

  login(loginModel: LoginModel): Observable<TokenModel> {
    return this.http.post<TokenModel>(
      this.apiUrl + 'login', JSON.stringify(loginModel), this.configService.getHttpOptions())
      .pipe(
        retry(1),
        catchError(this.exceptionService.throwError)
      );
  }

  signOut() {
    this.loggedInSource.next(false);
    this.tokenStorageService.signOut();
  }
}
