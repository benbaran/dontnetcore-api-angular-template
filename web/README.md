angular.json

          "options": {
            "outputPath": "wwwroot",

Add wwwroot to .gitignore


Create a Couple of Components

ng g component Toolbar
ng g component NotFound
ng g component Home



Install Material Components
ng add @angular/material

Install adal-angular4 npm package:

npm install adal-angular4

app.module.ts
import {AdalService, AdalInterceptor, AdalGuard} from 'adal-angular4';

 providers: [AdalService, AdalInterceptor, AdalGuard],

 Set up Routing

 app-routing.module.ts

 import { HomeComponent } from './home/home.component';
import { AdalGuard } from 'adal-angular4';
import { NotFoundComponent } from './not-found/not-found.component';

const routes: Routes = [
  {path: '', component: HomeComponent, canActivate: [AdalGuard]},
  {path: '**', component: NotFoundComponent}
];

Add app-toolbar to app.component.ts
<app-toolbar></app-toolbar>

Add Material Module
ng g module Material
add imports

Create the toolbar

Forms in app.component.ts
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

ng g class person/Person
ng g service person/Person
ng g component Person

  {path: 'person/:id', component: PersonComponent, canActivate: [AdalGuard]},
  
ng g component PersonSearch

providers: [AdalService, AdalInterceptor, AdalGuard, PersonService],

Add HTTPClientMudule

import {HttpClientModule} from '@angular/common/http';

