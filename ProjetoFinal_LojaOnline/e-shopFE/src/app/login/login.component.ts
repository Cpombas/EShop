import { Component, OnInit } from '@angular/core';
import { Form, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { empty } from 'rxjs';
import ValidateForm from '../shared/validateform';
import { AuthService } from '../services/auth.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
  
  loginForm!: FormGroup;

  constructor(private fb: FormBuilder, private authService: AuthService) {
  }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    })
  }

  onLogin(){
    if(this.loginForm.valid){
      console.log(this.loginForm.value)
      this.authService.login(this.loginForm.value)
      .subscribe({
        next:(res) => {
          alert(res.message)
          },
          error:(err) => {
            alert(err?.error.message)
          }
      })
       
    }
    else{
      ValidateForm.validateAllFormFields(this.loginForm);
      alert("Your form is invalid!")
    }
  }
}

