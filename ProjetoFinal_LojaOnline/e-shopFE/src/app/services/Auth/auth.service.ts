import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { User } from 'src/app/models/models';
import { JwtHelperService } from '@auth0/angular-jwt';

interface LoginResponse {
  token: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl = "https://localhost:7004/api/Authentication"
  private token: string | null = null;
  private currentUser: User | null = null;

  constructor(private http: HttpClient, private jwtHelper: JwtHelperService) {}

  public login(username: string, password: string) {
    return this.http.post<LoginResponse>(`${this.baseUrl}/login`, { username, password }).pipe(
      tap(response => {
        this.token = response.token;
        this.currentUser = this.jwtHelper.decodeToken(response.token) as User;
        localStorage.setItem('token', response.token);
      })
    );
  }

  public logout() {
    this.token = null;
    localStorage.removeItem('token');
  }

  public getToken(): string {
    if (!this.token) {
      this.token = localStorage.getItem('token') as string;
    }
    return this.token;
  }

  public getUser() {
    return this.currentUser;
  }

  public isLoggedIn(): boolean {
    return this.getToken() !== null;
  }
}
