import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map, of, tap } from 'rxjs';
import { User } from '../models/models';
import { UserService } from './user/user.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl:string = "https://localhost:7004/api/Authentication/"
  private token: string = '';
  private user: User = {
    userId: 0,
    userName: '',
    password: '',
    firstName: '',
    lastName: '',
    age: 0,
    email: '',
    address: '',
    role: '' 
  };
  

  constructor(private httpClient: HttpClient, private userService: UserService) { }

  register(regObj: any){
    return this.httpClient.post(`${this.baseUrl}register`, regObj)
  }

  login(username: string, password: string): Observable<any> {
    const body = { username, password };
    return this.httpClient.post(`${this.baseUrl}login`, body)
      .pipe(
        tap((res: any) => {
          console.log('res', res);
          localStorage.setItem('token', res);
        })
      );
  }
  

  public logout() {
    this.token = '';
    localStorage.removeItem('token');
  }

  public getToken(): string {
    const token = localStorage.getItem('token');
    if (!token) {
      throw new Error('No token found in local storage.');
    }
    this.token = token;
    return this.token;
  }
  

  public getUser(): Observable<User | undefined> {
    const token = this.getToken();
    
    if (!token) {
      return of(undefined);
    }
  
    const decodedToken = new JwtHelperService().decodeToken(token);
    const userId = Number(decodedToken.UserId);
    const userName = decodedToken.UserName;
    const role = decodedToken.Role;

    this.user.userId = userId;
    this.user.userName = userName;
    this.user.role = role;

    
    // Use the user service to fetch the user details
    return this.userService.getUser(this.user).pipe(
      map((users: User[]) => {
        if (users && users.length > 0) {
          return users[0];
        } else {
          return undefined;
        }
      })
    );
  }
  

  public isLoggedOff(): boolean {
    return this.getToken() === '';
  }
}

