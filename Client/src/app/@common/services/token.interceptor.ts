import { Observable                                                               } from 'rxjs'
import { tap                                                                      } from 'rxjs/operators'
import { HttpEvent      , HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from '@angular/common/http'
import { Injectable                                                               } from '@angular/core'
import { AppSettings                                                              } from '@helpers/app.settings'
import { Identity                                                                 } from '@models/identity.model'
import { IdentityService                                                          } from '@services/identity.service'

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  // ======================================= //
  constructor(private config: AppSettings, private identity: IdentityService) { }
  // ======================================= //

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const started = Date.now();
    return next.handle(req).pipe(
      tap(event => {
        if (event instanceof HttpResponse) {
          if (event.headers.has('Authorization')) {
            const token = event.headers.get('Authorization').replace('Bearer ', '');
            const user: any = event.body;
            this.identity.setIdentity(new Identity(user.userName, user.email, token));
          }
        }
      })
    );
  }
}