import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegFormComponent } from './reg-form/reg-form.component';
import { SigninComponent } from './signin/signin.component';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';
import { HomeComponent } from './home/home.component';
import { LazymoduleModule } from './lazymodule/lazymodule.module';
import { UsersComponent } from './users/users.component';
import { UserdetailsComponent } from './userdetails/userdetails.component';
import { PrimeuserComponent } from './users/primeuser/primeuser.component';
import { AuthGuard } from './auth.guard';
import { UpdatecompComponent } from './updatecomp/updatecomp.component';

@NgModule({
  declarations: [
    AppComponent,
    RegFormComponent,
    SigninComponent,
    PagenotfoundComponent,
    HomeComponent,
    UsersComponent,
    UserdetailsComponent,
    PrimeuserComponent,
    UpdatecompComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    LazymoduleModule
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
