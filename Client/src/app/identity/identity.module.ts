import { CommonModule          } from '@angular/common'
import { NgModule              } from '@angular/core'
import { ReactiveFormsModule   } from '@angular/forms'
import { IdentityRoutingModule } from '@identity/identity.routing.module'
import { LoginComponent        } from '@identity/login/login.component'
import { RegisterComponent     } from '@identity/register/register.component'
import { UserFormService       } from '@services/user-form.service'
import { IdentityComponent     } from './identity.component'

@NgModule({
  imports     : [CommonModule     , ReactiveFormsModule, IdentityRoutingModule],
  declarations: [IdentityComponent, LoginComponent, RegisterComponent         ],
  providers   : [UserFormService                                              ]
})
export class IdentityModule { }
