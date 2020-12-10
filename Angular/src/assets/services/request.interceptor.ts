import { Observable } from 'rxjs'
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { AppSettings } from '@assets/helpers/app.settings'

@Injectable()
export class RequestInterceptor implements HttpInterceptor {
  // ======================================= //
  constructor(private config: AppSettings) { }
  // ======================================= //

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const headers = req.headers
      .set('Content-Type', 'application/json');
    const authReq = req.clone({ headers });
    return next.handle(authReq);
  }
}