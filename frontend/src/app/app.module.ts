import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {ReactiveFormsModule} from '@angular/forms';
import {UserService} from './services/user.service';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {UserAddComponent} from './pages/users/user-add/user-add.component';
import {UserEditComponent} from './pages/users/user-edit/user-edit.component';
import {UserListComponent} from './pages/users/user-list/user-list.component';
import {RoomService} from './services/room.service';
import {ReservationService} from './services/reservation.service';
import {AuthService} from './services/auth.service';
import {UserDetailsComponent} from './pages/users/user-details/user-details.component';
import {LoaderComponent} from './common/loader/loader.component';
import {LoginComponent} from './pages/auth/login/login.component';
import {ExceptionService} from './services/exception.service';
import {RoomListComponent} from './pages/rooms/room-list/room-list.component';
import {JwtInterceptor} from './utils/jwt-interceptor';
import {TokenStorageService} from './services/token.storage.service';
import {NavbarComponent} from './common/navbar/navbar.component';
import { ConfirmComponent } from './common/confirm/confirm.component';

@NgModule({
  declarations: [
    AppComponent,
    UserAddComponent,
    UserEditComponent,
    UserListComponent,
    UserDetailsComponent,
    LoaderComponent,
    LoginComponent,
    RoomListComponent,
    NavbarComponent,
    ConfirmComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [
    TokenStorageService,
    AuthService,
    ExceptionService,
    UserService,
    RoomService,
    ReservationService,

    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
