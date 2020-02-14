import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {UserListComponent} from './pages/users/user-list/user-list.component';
import {UserEditComponent} from './pages/users/user-edit/user-edit.component';
import {LoginComponent} from './pages/auth/login/login.component';
import {AuthGuard} from './utils/auth.guard';
import {RoomListComponent} from './pages/rooms/room-list/room-list.component';
import {RoomEditComponent} from './pages/rooms/room-edit/room-edit.component';
import {RoomDetailsComponent} from './pages/rooms/room-details/room-details.component';
import {ReservationEditComponent} from './pages/reservations/reservation-edit/reservation-edit.component';
import {ReservationListComponent} from './pages/reservations/reservation-list/reservation-list.component';

const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: 'user-list', component: UserListComponent, canActivate: [AuthGuard]},
  {path: 'user-edit', component: UserEditComponent, canActivate: [AuthGuard]},
  {path: 'user-edit/:id', component: UserEditComponent, canActivate: [AuthGuard]},
  {path: 'room-list', component: RoomListComponent, canActivate: [AuthGuard]},
  {path: 'room-edit', component: RoomEditComponent, canActivate: [AuthGuard]},
  {path: 'room-edit/:id', component: RoomEditComponent, canActivate: [AuthGuard]},
  {path: 'room-details/:id', component: RoomDetailsComponent, canActivate: [AuthGuard]},
  {path: 'reservation-list', component: ReservationListComponent, canActivate: [AuthGuard]},
  {path: 'reservation-edit/:id', component: ReservationEditComponent, canActivate: [AuthGuard]},
  {path: '', component: RoomListComponent, canActivate: [AuthGuard], pathMatch: 'full'},
  {path: '**', redirectTo: '/'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
