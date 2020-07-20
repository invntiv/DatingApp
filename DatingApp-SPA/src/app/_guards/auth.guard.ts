import { Injectable } from '@angular/core';
import { CanActivate, Router} from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';

@Injectable({
  providedIn: 'root'
})

/*
    Guard that checks authentication using autherService.loggedIn() then is applied to a route --
    true or false 
*/
export class AuthGuard implements CanActivate {
  constructor(
    private authService: AuthService,
    private router: Router,
    private alertify: AlertifyService
    ) {}

  canActivate(): boolean {
    if (this.authService.loggedIn()){
      return true;
    }

    this.alertify.error('You Shall Not Pass!!!');
    this.router.navigate(['/home']);
    return false;
  }
}
