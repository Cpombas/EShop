import { Injectable, Input } from '@angular/core';
import { UserService } from '../user/user.service';
import { User } from 'src/app/models/models';
import { AuthService } from '../Auth/auth.service';


@Injectable({
  providedIn: 'root'
})
export class RoleService {
  @Input() user?: User;

  constructor(private authService: AuthService, private userService: UserService) { }

  public isAdmin(): boolean {
    const _user = this.authService.getUser();
    return (_user && _user.role === 'admin') as boolean;
  }

  public isManager(): boolean {
    const _user = this.authService.getUser();
    return (_user && _user.role === 'manager') as boolean;
  }

  public isUser(): boolean {
    const _user = this.authService.getUser();
    return (_user && _user.role === 'user') as boolean;
  }

  public isGuest(): boolean {
    const _user = this.authService.getUser();
    return !_user;
  }
}

