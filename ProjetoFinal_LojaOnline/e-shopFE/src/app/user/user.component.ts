import { Component, OnInit } from '@angular/core';
import { User } from '../models/models';
import { UserService } from '../services/user/user.service'

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit{
  users: User[] = [];
  userToEdit?: User; 
  visible = false;

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.userService.getUserList()
    .subscribe((result: User[]) => {this.users = result});
  }

  updateUserList(users: User[]) {
    this.users = users;
  }

  initNewUser() {
    this.userToEdit = new User();
  }

  editUser(user: User){
    this.userToEdit = user;
  }

  toggleCollapse(): void {
    this.visible = !this.visible;
  }
}
