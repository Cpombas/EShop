import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/Auth/auth.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username: string='';
  password: string='';

  constructor() {}

  // onSubmit() {
  //   if (this.authService.login(this.username, this.password)) {
  //     this.router.navigate(['/home']);
  //   }
  // }
}

