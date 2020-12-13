import { Observable } from 'rxjs'
import { Injectable } from '@angular/core'
import { ActivatedRouteSnapshot, Resolve, Router } from '@angular/router'
import { IdentityService } from '@services/identity.service'

@Injectable()
export class IdentityResolver implements Resolve<any> {
  // ======================================= //
  constructor(private identity: IdentityService, private router: Router) { }
  // ======================================= //

  resolve(route: ActivatedRouteSnapshot): Observable<any> | Promise<any> | any {

  }
}