import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthserviceService } from './authservice.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService:AuthserviceService){}
  canActivate(){
    if(this.authService.isUserLoggedIn()){
      return true;
    }
    else{
      alert('Permission Denied');
      return false;
    }
    
  }

  
}
