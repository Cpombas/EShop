import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import ValidateForm from '../shared/validateform';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  registerForm!: FormGroup;

  constructor(private fb: FormBuilder, private authService: AuthService) {
  }

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    })
  }

  onRegister(){
    if(this.registerForm.valid){
      console.log(this.registerForm.value)
      this.authService.login(this.registerForm.value)
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
      ValidateForm.validateAllFormFields(this.registerForm);
      alert("Your form is invalid!")
    }
  }
}
