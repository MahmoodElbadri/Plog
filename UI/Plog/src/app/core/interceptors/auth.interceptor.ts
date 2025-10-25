import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { CookieService } from 'ngx-cookie-service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private cookieSer: CookieService) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    if(!this.shouldInterceptUrl(request)) {
      return next.handle(request);
    }
    const modifiedReq = request.clone({
      setHeaders: {
        'Authorization': this.cookieSer.get('Authorization')
      }
    });
    return next.handle(modifiedReq);
  }

  private shouldInterceptUrl(request: HttpRequest<any>): boolean {
    return request.urlWithParams.indexOf('AddAuth=true', 0) > -1 ? true : false;
  }
}
