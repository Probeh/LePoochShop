import { Observable                                                 } from 'rxjs'
import { HttpEvent      , HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http'
import { Injectable                                                 } from '@angular/core'
import { AppSettings                                                } from '@helpers/app.settings'
import { IdentityService                                            } from '@services/identity.service'

@Injectable()
export class RequestInterceptor implements HttpInterceptor {
  // ======================================= //
  constructor(private config: AppSettings, private identity: IdentityService) { }
  // ======================================= //

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    console.log('Authorization', `Bearer ${this.identity.identity?.token}`);
    const authReq = req.clone({
      setHeaders: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.identity.identity?.token}`
      }
    });
    return next.handle(authReq);
  }
}