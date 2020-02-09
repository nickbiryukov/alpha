import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {ListUserComponent} from './pages/users/list-user/list-user.component';


const routes: Routes = [
  { path: '', component: ListUserComponent, pathMatch: 'full' },
  { path: 'users', component: ListUserComponent},
  { path: '**', redirectTo: '/' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
