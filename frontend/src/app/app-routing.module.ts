import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {UserListComponent} from './pages/users/user-list/user-list.component';
import {UserDetailsComponent} from './pages/users/user-details/user-details.component';
import {UserAddComponent} from './pages/users/user-add/user-add.component';
import {LoginComponent} from './pages/auth/login/login.component';
import {AuthGuard} from './utils/auth.guard';
import {RoomListComponent} from './pages/rooms/room-list/room-list.component';

const routes: Routes = [
  {path: '', component: UserListComponent, canActivate: [AuthGuard], pathMatch: 'full'},
  {path: 'users', component: UserListComponent, canActivate: [AuthGuard]},
  {path: 'login', component: LoginComponent},
  {path: 'rooms', component: RoomListComponent, canActivate: [AuthGuard]},
  {path: 'user-details/:id', component: UserDetailsComponent},
  {path: 'user-edit/:id', component: UserAddComponent},
  {path: '**', redirectTo: '/'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
