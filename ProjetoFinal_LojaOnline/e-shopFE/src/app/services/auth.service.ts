import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl:string = "https://localhost:7004/api/Authentication/"

  constructor(private httpClient: HttpClient) { }

  register(regObj: any){
    return this.httpClient.post(`${this.baseUrl}register`, regObj)
  }

  login(username: string, password: string): Observable<any> {
    const body = { username, password };
    return this.httpClient.post(`${this.baseUrl}login`, body)
  }
}


