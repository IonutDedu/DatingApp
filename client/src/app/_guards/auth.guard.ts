import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { AccoutService } from '../_services/accout.service';
import { ToastrService } from 'ngx-toastr';

export const authGuard: CanActivateFn = (route, state) => {
  const accountService = inject(AccoutService);
  const toastr = inject(ToastrService);

  if (accountService.currentUser()){
    return true;
  } else {
    toastr.error('You shall not pass!');
    return false;
  }
};
