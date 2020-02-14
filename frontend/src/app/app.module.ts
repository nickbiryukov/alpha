import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {ReactiveFormsModule} from '@angular/forms';
import {UserService} from './services/user.service';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {UserEditComponent} from './pages/users/user-edit/user-edit.component';
import {UserListComponent} from './pages/users/user-list/user-list.component';
import {RoomService} from './services/room.service';
import {ReservationService} from './services/reservation.service';
import {AuthService} from './services/auth.service';
import {LoaderComponent} from './common/loader/loader.component';
import {LoginComponent} from './pages/auth/login/login.component';
import {ExceptionService} from './services/exception.service';
import {RoomListComponent} from './pages/rooms/room-list/room-list.component';
import {JwtInterceptor} from './utils/jwt-interceptor';
import {TokenStorageService} from './services/token.storage.service';
import {NavbarComponent} from './common/navbar/navbar.component';
import {EnumToArrayPipe} from './common/pipes/enum-to-array.pipe';
import {RoomEditComponent} from './pages/rooms/room-edit/room-edit.component';
import {RoomDetailsComponent} from './pages/rooms/room-details/room-details.component';
import {ReservationDetailsComponent} from './pages/reservations/reservation-details/reservation-details.component';
import {ReservationListComponent} from './pages/reservations/reservation-list/reservation-list.component';
import {ReservationEditComponent} from './pages/reservations/reservation-edit/reservation-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    UserEditComponent,
    UserListComponent,
    LoaderComponent,
    LoginComponent,
    RoomListComponent,
    NavbarComponent,
    EnumToArrayPipe,
    RoomEditComponent,
    RoomDetailsComponent,
    ReservationDetailsComponent,
    ReservationListComponent,
    ReservationEditComponent
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
export class AppModule {
}
