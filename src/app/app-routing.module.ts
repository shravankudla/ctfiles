import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegFormComponent } from './reg-form/reg-form.component';
import { SigninComponent } from './signin/signin.component';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';
import { HomeComponent } from './home/home.component';
import { UsersComponent } from './users/users.component';
import { UserdetailsComponent } from './userdetails/userdetails.component';
import { PrimeuserComponent } from './users/primeuser/primeuser.component';
import { UpdatecompComponent } from './updatecomp/updatecomp.component';
import { AuthGuard } from './auth.guard';

const routes: Routes = [
  {path:'',component:HomeComponent},
  // {path:'', redirectTo:'/regform', pathMatch:'full'}, // if you want to open directly registration form
  {path:'regform',component:RegFormComponent},
  {path:'signin',component:SigninComponent ,canActivate:[AuthGuard]},
  {path:'update',component:UpdatecompComponent},
  {path:'lazymodule',
  loadChildren: () => import('./lazymodule/lazymodule.module').then(m => m.LazymoduleModule)},
  {path:'user',children:[
    {path:'',component:UsersComponent},
    {path:'prime',component:PrimeuserComponent}
  ]},
  // {path:'postcomp',component:PostcompComponent},
  {path:'userdetail/:id',component:UserdetailsComponent},
  {path:'**',component:PagenotfoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
