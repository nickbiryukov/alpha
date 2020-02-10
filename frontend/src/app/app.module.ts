import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {ReactiveFormsModule} from '@angular/forms';
import {UserService} from './services/user.service';
import {HttpClientModule} from '@angular/common/http';
import { AddUserComponent } from './pages/users/add-user/add-user.component';
import { EditUserComponent } from './pages/users/edit-user/edit-user.component';
import { ListUserComponent } from './pages/users/list-user/list-user.component';
import {RoomService} from './services/room.service';
import {ReservationService} from './services/reservation.service';
import {AuthService} from './services/auth.service';
import { AddRoomComponent } from './pages/rooms/add-room/add-room.component';
import { ListRoomComponent } from './pages/rooms/list-room/list-room.component';
import { EditRoomComponent } from './pages/rooms/edit-room/edit-room.component';
import { DetailUserComponent } from './pages/users/detail-user/detail-user.component';
import { LoaderComponent } from './common/loader/loader.component';
import {authInterceptorProviders} from './utils/auth.interceptor';
import { LoginComponent } from './pages/auth/login/login.component';
import { ConfigService } from './services/config.service';
import { JwtStorageService } from './services/jwt.storage.service';
import {ExceptionService} from './services/exception.service';

@NgModule({
  declarations: [
    AppComponent,
    AddUserComponent,
    EditUserComponent,
    ListUserComponent,
    AddRoomComponent,
    ListRoomComponent,
    EditRoomComponent,
    DetailUserComponent,
    LoaderComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [
    AuthService,
    UserService,
    RoomService,
    ReservationService,
    ExceptionService
    /*authInterceptorProviders*/
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
