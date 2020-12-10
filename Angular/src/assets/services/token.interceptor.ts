import { Observable } from 'rxjs'
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { AppSettings } from '@assets/helpers/app.settings'

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  // ======================================= //
  constructor(private config: AppSettings) {}
  // ======================================= //
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req);
  }
}