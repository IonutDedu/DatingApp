import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { AccoutService } from '../_services/accout.service';

export const jwtInterceptor: HttpInterceptorFn = (req, next) => {
  const accountService = inject(AccoutService);

  if (accountService.currentUser()){
    req = req.clone({
      setHeaders:{
        Authorization: `Bearer ${accountService.currentUser()?.token}`
      }
    })
  }

  return next(req);
};
