import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class ScheduleService {

  constructor(private http: HttpClient) { }

}
