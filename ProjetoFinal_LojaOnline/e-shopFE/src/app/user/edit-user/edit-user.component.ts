import { Component, EventEmitter, Input, Output } from '@angular/core';
import { User } from 'src/app/models/models';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent {
  @Input() user?: User;
  @Output() userUpdated = new EventEmitter<User[]>();

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    
  }

  createUser(user: User) {
    this.userService
    .createUser(user)
    .subscribe({
      next: (res) => {
        (users: User[]) => this.userUpdated.emit(users)
      },
      error: (err) => {console.log(err);}
    });
  }

  updateUser(user: User) {
    this.userService
    .updateUser(user)
    .subscribe({
      next: (res) => {
        (users: User[]) => this.userUpdated.emit(users)
      },
      error: (err) => {console.log(err);}
    });
  }

  deleteUser(user: User) {
    this.userService
    .deleteUser(user)
    .subscribe({
      next: (res) => {
        (users: User[]) => this.userUpdated.emit(users)
      },
      error: (err) => {console.log(err);}
    });
  }
}
