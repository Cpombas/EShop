import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl:string = "https://localhost:7004/api/Authentication/"
  private token: string = '';

  constructor(private httpClient: HttpClient) { }

  register(regObj: any){
    return this.httpClient.post(`${this.baseUrl}register`, regObj)
  }

  login(username: string, password: string): Observable<any> {
    const body = { username, password };
    return this.httpClient.post(`${this.baseUrl}login`, body)
  }

  public logout() {
    this.token = '';
    localStorage.removeItem('token');
  }

  public getToken(): string {
    if (this.token === '') {
      this.token = localStorage.getItem('token') as string;
    }
    return this.token;
  }

  public isLoggedIn(): boolean {
    return this.getToken() !== null;
  }
}


