import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { HomeComponent } from './home/home.component';

import { AdalService, AdalInterceptor, AdalGuard } from 'adal-angular4';
import { MaterialModule } from './material/material.module';
import { PersonComponent } from './person/person.component';
import { PersonSearchComponent } from './person/person-search.component';
import { PersonService } from './person/person.service';


@NgModule({
  declarations: [
    AppComponent,
    ToolbarComponent,
    NotFoundComponent,
    HomeComponent,
    PersonComponent,
    PersonSearchComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    HttpClientModule
  ],
  providers: [AdalService, AdalInterceptor, AdalGuard, PersonService],
  bootstrap: [AppComponent]
})
export class AppModule { }
