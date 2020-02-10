import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {ListUserComponent} from './pages/users/list-user/list-user.component';
import {DetailUserComponent} from './pages/users/detail-user/detail-user.component';
import {AddUserComponent} from './pages/users/add-user/add-user.component';
import { LoginComponent } from './pages/auth/login/login.component';

const routes: Routes = [
  { path: '', component: ListUserComponent, pathMatch: 'full' },
  { path: 'users', component: ListUserComponent},
  { path: 'login', component: LoginComponent},
  { path: 'detail-user/:id', component: DetailUserComponent},
  { path: 'edit-user/:id', component: AddUserComponent},
  { path: '**', redirectTo: '/' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
