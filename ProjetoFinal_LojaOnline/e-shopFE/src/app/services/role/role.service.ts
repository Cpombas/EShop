import { Injectable } from '@angular/core';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  constructor() { }

  public hasRole(role: string): boolean {
    const token = localStorage.getItem('token');
    if (token) {
      const decodedToken = jwt_decode(token) as { id: number, username: string, role: string };;
      return decodedToken.role === role;
    }
    return false;
  }

  public getRole(): string {
    const token = localStorage.getItem('token');
    if (token) {
      const decodedToken = jwt_decode(token) as { id: number, username: string, role: string };;
      return decodedToken.role;
    }
    return '';
  }

}

