import { CommonModule } from '@angular/common'
import { NgModule } from '@angular/core'
import { FormsModule } from '@angular/forms'
import { AccountRouterModule } from '@identity/account/account-routing.module'
import { AccountComponent } from '@identity/account/account.component'
import { LoginComponent } from '@identity/account/login/login.component'
import { RegisterComponent } from '@identity/account/register/register.component'

// ======================================= //
const components = [LoginComponent, RegisterComponent, AccountComponent];
// ======================================= //
@NgModule({
  imports: [CommonModule, FormsModule, AccountRouterModule],
  declarations: components,
  exports: components,
})
// ======================================= //
export class AccountModule { }
