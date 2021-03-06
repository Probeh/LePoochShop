import { NgModule                  } from '@angular/core'
import { RouterModule     , Routes } from '@angular/router'
import { IdentityComponent         } from '@identity/identity.component'         ;
import { LoginComponent            } from '@identity/login/login.component'
import { RegisterComponent         } from '@identity/register/register.component'

const routes: Routes = [
  // ======================================= //
  { path: ''        , component:         IdentityComponent          },
  { path: 'login'   , component:         LoginComponent             },
  { path: 'register', component:         RegisterComponent          },
  { path: '**'      , pathMatch: 'full', redirectTo       : 'login' }
];
// ======================================= //
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class IdentityRoutingModule { }
