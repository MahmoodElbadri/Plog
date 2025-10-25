import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginRequestModel } from '../models/login-request-model';
import { BehaviorSubject, Observable } from 'rxjs';
import { LoginResponse } from '../models/login-response';
import { environment } from 'environments/environment';
import { User } from '../models/user';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  $user = new BehaviorSubject<User | undefined>(undefined);
  constructor(private http: HttpClient,
    private cookieService: CookieService
  ) { }

  login(model: LoginRequestModel): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${environment.apiUrl}/auth/login`, {
      email: model.email,
      password: model.password
    });
  }

  setUser(user: User): void {
    this.$user.next(user);
    localStorage.setItem("user-email", user.email);
    localStorage.setItem("user-roles", user.roles.join(","));
  }

  user(): Observable<User | undefined> {
    return this.$user.asObservable();
  }

  getUser(): User | undefined {
    const email = localStorage.getItem("user-email");
    const roles = localStorage.getItem("user-roles");
    if (email && roles) {
      return {
        email: email,
        roles: roles.split(",")
      };
    }
    return undefined;
  }

  logOut(): void {
    localStorage.clear();
    this.cookieService.delete("Authorization", "/");
    this.$user.next(undefined);
  }
}
