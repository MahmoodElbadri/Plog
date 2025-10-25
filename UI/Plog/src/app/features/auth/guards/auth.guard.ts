import { CanActivateFn, Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { AuthService } from '../services/auth.service';
import { inject } from '@angular/core';
import { jwtDecode } from 'jwt-decode';

export const authGuard: CanActivateFn = (route, state) => {
  const cookieService = inject(CookieService);
  const authService = inject(AuthService);
  const router = inject(Router);
  const user = authService.getUser();
  let token = cookieService.get('Authorization');

  if (!token) {
    authService.logOut();
    return router.createUrlTree(['/login'], { queryParams: { returnUrl: state.url } });
  }
  token = token.replace('Bearer ', '');
  const decodedToken: any = jwtDecode(token);
  const expiryDate = new Date(decodedToken.exp * 1000);

  if (expiryDate < new Date()) {
    authService.logOut();
    return router.createUrlTree(['/login'], { queryParams: { returnUrl: state.url } });
  } else {
    if (user?.roles.includes('Writer')) {
      return true;
    }
    alert('You are not authorized to access this page');
    return router.createUrlTree(['/']);
  }
  return true;
};
