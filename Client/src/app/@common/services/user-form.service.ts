import { Injectable } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Injectable()
export class UserFormService {
  // ======================================= //
  constructor() { }
  // ======================================= //
  public generateLoginForm() {
    return new FormGroup({
      'username': new FormControl('', Validators.required),
      'password': new FormControl('', Validators.required)
    });
  }
  public generateRegisterForm() {
    return new FormGroup({
      'username': new FormControl('',  Validators.required                   ),
      'password': new FormControl('',  Validators.required                   ),
      'email'   : new FormControl('', [Validators.required, Validators.email]),
    });
  }
}
