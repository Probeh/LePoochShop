import { Subject } from 'rxjs'
import { Injectable } from '@angular/core'

@Injectable()
export class DialogService {
  public showDialog$: Subject<boolean> = new Subject();
  public hideDialog$: Subject<boolean> = new Subject();
  // ======================================= //
  constructor() { }
  // ======================================= //
  public showDialog() {
    this.showDialog$.next();
  }
  public hideDialog() {
    this.hideDialog$.next();
  }
}
