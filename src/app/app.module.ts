import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { OpeaComponent } from './opea/opea.component';
import { ShowOpeaComponent } from './opea/show-opea/show-opea.component';
import { AddEditOpeaComponent } from './opea/add-edit-opea/add-edit-opea.component';
import { OpeaApiService } from './opea-api.service';

@NgModule({
  declarations: [
    AppComponent,
    OpeaComponent,
    ShowOpeaComponent,
    AddEditOpeaComponent    
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule    
  ],
  providers: [OpeaApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
