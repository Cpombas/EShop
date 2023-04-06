import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import ValidateForm from '../shared/validateform';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  regObj ={
    username: "",
    password: "",
    firstname: "",
    lastname: "",
    age: undefined,
    email: "",
    address: ""
  };

  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router) {
  }

  ngOnInit(): void {
  }

  onRegister(){
    this.authService.register(this.regObj).subscribe(res => {
      console.log('res', res)
      this.router.navigate(['/login'])
    });
  }
}
