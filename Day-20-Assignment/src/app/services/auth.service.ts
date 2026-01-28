import { Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, tap, map, catchError, of } from 'rxjs';

export interface User {
  id: number;
  email: string;
  password: string;
  name: string;
}

export interface Token {
  id: number;
  userId: number;
  token: string;
  createdAt: string;
}

export interface LoginResponse {
  success: boolean;
  token?: string;
  user?: User;
  message?: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:3001';
  public isAuthenticated = signal(false);
  public currentUser = signal<User | null>(null);

  constructor(private http: HttpClient, private router: Router) {
    this.checkAuthStatus();
  }

  private checkAuthStatus() {
    const token = this.getToken();
    if (token) {
      const user = this.getCurrentUser();
      if (user) {
        this.isAuthenticated.set(true);
        this.currentUser.set(user);
      }
    }
  }

  login(email: string, password: string): Observable<LoginResponse> {
    return this.http.get<User[]>(`${this.apiUrl}/users?email=${email}&password=${password}`)
      .pipe(
        map(users => {
          if (users.length > 0) {
            const user = users[0];
            const token = this.generateToken();
            this.setToken(token);
            this.setCurrentUser(user);
            this.isAuthenticated.set(true);
            this.currentUser.set(user);
            
            // Store token in db.json
            this.http.post(`${this.apiUrl}/tokens`, {
              userId: user.id,
              token: token,
              createdAt: new Date().toISOString()
            }).subscribe();

            return { success: true, token, user };
          } else {
            return { success: false, message: 'Invalid credentials' };
          }
        }),
        catchError(error => {
          console.error('Login error:', error);
          return of({ success: false, message: 'Login failed' });
        })
      );
  }

  register(email: string, password: string, name: string): Observable<LoginResponse> {
    return this.http.get<User[]>(`${this.apiUrl}/users?email=${email}`)
      .pipe(
        map(users => {
          if (users.length > 0) {
            return { success: false, message: 'Email already exists' };
          }
          return null;
        }),
        tap(result => {
          if (!result) {
            this.http.post<User>(`${this.apiUrl}/users`, {
              email,
              password,
              name
            }).pipe(
              tap(user => {
                const token = this.generateToken();
                this.setToken(token);
                this.setCurrentUser(user);
                this.isAuthenticated.set(true);
                this.currentUser.set(user);
                
                // Store token in db.json
                this.http.post(`${this.apiUrl}/tokens`, {
                  userId: user.id,
                  token: token,
                  createdAt: new Date().toISOString()
                }).subscribe();
              })
            ).subscribe();
          }
        }),
        map(result => {
          if (result) {
            return result;
          }
          return { success: true, message: 'Registration successful' };
        }),
        catchError(error => {
          console.error('Registration error:', error);
          return of({ success: false, message: 'Registration failed' });
        })
      );
  }

  logout() {
    const token = this.getToken();
    if (token) {
      // Remove token from db.json
      this.http.get<Token[]>(`${this.apiUrl}/tokens?token=${token}`)
        .subscribe(tokens => {
          if (tokens.length > 0) {
            this.http.delete(`${this.apiUrl}/tokens/${tokens[0].id}`).subscribe();
          }
        });
    }
    
    this.removeToken();
    this.removeCurrentUser();
    this.isAuthenticated.set(false);
    this.currentUser.set(null);
    this.router.navigate(['/login']);
  }

  private generateToken(): string {
    return Math.random().toString(36).substr(2) + Date.now().toString(36);
  }

  private setToken(token: string) {
    localStorage.setItem('auth_token', token);
  }

  getToken(): string | null {
    return localStorage.getItem('auth_token');
  }

  private removeToken() {
    localStorage.removeItem('auth_token');
  }

  private setCurrentUser(user: User) {
    localStorage.setItem('current_user', JSON.stringify(user));
  }

  private getCurrentUser(): User | null {
    const userStr = localStorage.getItem('current_user');
    return userStr ? JSON.parse(userStr) : null;
  }

  private removeCurrentUser() {
    localStorage.removeItem('current_user');
  }

  isLoggedIn(): boolean {
    return this.getToken() !== null;
  }
}
