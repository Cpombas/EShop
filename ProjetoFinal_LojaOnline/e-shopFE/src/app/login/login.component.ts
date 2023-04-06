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
  
  username: string = '';
  password: string = '';

  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router) {}
  

  ngOnInit(): void {
    // this.loginForm = this.fb.group({
    //   username: ['', Validators.required],
    //   password: ['', Validators.required]
    // })
  }

  onLogin() {
    this.authService.login(this.username, this.password).subscribe(res => {
      console.log('res', res)
      localStorage.setItem('token', res.token)
      this.router.navigate(['/home'])
    });
  }
  
}
  // onLogin(){
  //   if(this.loginForm.valid){
  //     console.log(this.loginForm.value)
  //     this.authService.login(this.loginForm.value)
  //     .subscribe({
  //       next:(res) => {
  //         alert(res.message);
  //         this.loginForm.reset();
  //         this.router.navigate(['home']);
  //         },
  //         error:(err) => {
  //           alert(err?.error.message)
  //         }
  //     })
       
  //   }
  //   else{
  //     ValidateForm.validateAllFormFields(this.loginForm);
  //     alert("Your form is invalid!")
  //   }
  // }


