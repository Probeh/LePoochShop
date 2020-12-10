
import { Injectable } from '@angular/core'
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router'
import { IdentityService } from '@assets/services/identity.service'

@Injectable()
export class IdentityGuard implements CanActivate {
  // ======================================= //
  constructor(private identity: IdentityService, private router: Router) { }
  // ======================================= //

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (!this.identity.authState) {
      this.router.navigate(['/identity']);
      return false;
    }
    return true;
  }
}