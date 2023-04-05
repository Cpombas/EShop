import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl:string = "https://localhost:7004/api/Authentication/"
  
  constructor(private httpClient: HttpClient) { }

  register(regObj: any){
    return this.httpClient.post<any>(`${this.baseUrl}register`, regObj)
  }

  login(logObj: any){
    return this.httpClient.post<any>(`${this.baseUrl}login`, logObj)
  }
}
