import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'

@Injectable()
export class ErrorService {
  // ======================================= //
  constructor(private http: HttpClient) { }
  // ======================================= //
}
