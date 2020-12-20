import { HttpErrorResponse         } from '@angular/common/http'
import { Component        , OnInit } from '@angular/core'
import { FormGroup                 } from '@angular/forms'
import { Router                    } from '@angular/router'
import { Account                   } from '@models/account.model'
import { IdentityService           } from '@services/identity.service'
import { UserFormService           } from '@services/user-form.service'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public formGroup: FormGroup;
  // ======================================= //
  constructor(private identity: IdentityService, private formService: UserFormService, private router: Router) { }
  ngOnInit() { this.formGroup = this.formService.generateLoginForm(); }
  // ======================================= //
  public login() {
    const value = this.formGroup.value;
    this.identity.userLogin(new Account(value.username, value.password, value.email))
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
          Object.keys(response.error.errors)
            .forEach(field => {
              this.formGroup.controls[field.toLowerCase()]?.setErrors(field.toLowerCase().match('username')
                ? { username: response.error.errors[field] }
                : { password: response.error.errors[field] });
            });
        }
      });
  }
  public getErrors(control: string) {
    return Object.keys(this.formGroup.get(control).errors);
  }
}