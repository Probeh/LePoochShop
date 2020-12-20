import { HttpErrorResponse } from '@angular/common/http'
import { Component, OnInit } from '@angular/core'
import { FormGroup } from '@angular/forms'
import { Router } from '@angular/router'
import { Account } from '@models/account.model'
import { IdentityService } from '@services/identity.service'
import { UserFormService } from '@services/user-form.service'

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  public formGroup: FormGroup;
  // ======================================= //
  constructor(private identity: IdentityService, private formService: UserFormService, private router: Router) { }
  ngOnInit() { this.formGroup = this.formService.generateRegisterForm(); }
  // ======================================= //
  public register() {
    this.identity.userRegister(new Account(this.formGroup.value.username, this.formGroup.value.password, this.formGroup.value.email))
      .then(result => {
        this.formGroup.reset();
        this.router.navigateByUrl('schedule');
      })
      .catch((response: HttpErrorResponse) => {
        if (response.status == 401) {
          Object.keys(response.error)
            .forEach(field => {
              if (this.formGroup.controls[field.toLowerCase()]) {
                this.formGroup.controls[field.toLowerCase()]?.setErrors(
                  field.toLowerCase().match('username')
                    ? { username: response.error[field]['errors'][0]['errorMessage'] }
                    : { password: response.error[field]['errors'][0]['errorMessage'] });
              }
              else this.formGroup.setErrors({ 'credentials': response.error })
            });
        }
        else if (response.status == 400) {
          if (response.error.errors) {
            Object.keys(response.error.errors)
              .forEach(field => {
                switch (field.toLowerCase()) {
                  case 'username':
                    this.formGroup
                      .controls[field.toLowerCase()]
                      .setErrors({ 'username': response.error.errors[field][0] });
                    break;
                  case 'password':
                    this.formGroup
                      .controls[field.toLowerCase()]
                      .setErrors({ 'password': response.error.errors[field][0] });
                    break;
                  case 'email':
                    this.formGroup
                      .controls[field.toLowerCase()]
                      .setErrors({ 'email': response.error.errors[field][0] });
                    break;
                }
              });
          }
          else {
            Object.keys(response.error).forEach(field => {
              switch (field.toLowerCase()) {
                case 'username':
                  this.formGroup
                    .controls[field.toLowerCase()]
                    .setErrors({ 'username': response.error[field][0] });
                  break;
                case 'password':
                  this.formGroup
                    .controls[field.toLowerCase()]
                    .setErrors({ 'password': response.error[field][0] });
                  break;
                case 'email':
                  this.formGroup
                    .controls[field.toLowerCase()]
                    .setErrors({ 'email': response.error[field][0] });
                  break;
              }
            });
          }
        }
      });
  }
  public getErrors(control: string) {
    return Object.keys(this.formGroup.get(control).errors);
  }
}