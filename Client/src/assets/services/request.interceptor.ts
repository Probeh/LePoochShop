import { Observable } from 'rxjs'
import { HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor, HttpRequest } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { AppSettings } from '@helpers/app.settings'

@Injectable()
export class RequestInterceptor implements HttpInterceptor {
  // ======================================= //
  constructor(private config: AppSettings) { }
  // ======================================= //

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const authReq = req.clone({
      headers: new HttpHeaders({'Content-Type': 'application/json'}),
    });
    return next.handle(authReq);
  }
}