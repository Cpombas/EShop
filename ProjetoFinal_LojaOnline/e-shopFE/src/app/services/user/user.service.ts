import { Injectable } from '@angular/core';
import { User } from 'src/app/models/models';
import { HttpClient } from "@angular/common/http"
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})

export class UserService {
  private baseUrl = "https://localhost:7004/api/User"

  constructor(private httpClient: HttpClient) { }

  public getUserList(): Observable<User[]> {
    return this.httpClient.get<User[]>(`${this.baseUrl}`);
  }

  public getUser(user: User): Observable<User[]> {
    return this.httpClient.get<User[]>(`${this.baseUrl}/id?id=${user.userId}`)
  }

  public createUser(user: User) :  Observable<User[]> {
    return this.httpClient.post<User[]>(`${this.baseUrl}`, user);
  }

  public updateUser(user: User) :  Observable<User[]> {
    return this.httpClient.put<User[]>(`${this.baseUrl}/id?id=${user.userId}`, user);
  }

  public deleteUser(user: User) :  Observable<User[]> {
    return this.httpClient.delete<User[]>(`${this.baseUrl}/id?id=${user.userId}`);
  }
}