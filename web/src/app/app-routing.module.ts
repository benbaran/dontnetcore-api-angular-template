import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AdalGuard } from 'adal-angular4';
import { NotFoundComponent } from './not-found/not-found.component';
import { PersonComponent } from './person/person.component';

const routes: Routes = [
  {path: '', component: HomeComponent, canActivate: [AdalGuard]},
  {path: 'person/:id', component: PersonComponent, canActivate: [AdalGuard]},
  {path: '**', component: NotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
