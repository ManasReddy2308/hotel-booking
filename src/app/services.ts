import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl = 'http://localhost:5126/api/Auth';

  constructor(private http: HttpClient) {}

  login(email: string, password: string) {
    return this.http.post(`${this.baseUrl}/login`, { email, password });
  }

  register(name: string, email: string, password: string) {
    return this.http.post(`${this.baseUrl}/register`, { name, email, password });
  }

  guestLogin() {
    return this.http.get(`${this.baseUrl}/guest`);
  }
}