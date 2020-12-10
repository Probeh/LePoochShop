import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { IdentityGuard } from '@assets/services/identity.guard'

// ======================================= //
const routes: Routes = [
  { path: 'profile', canLoad: [IdentityGuard], loadChildren: () => import('./profile/profile.module').then(m => m.ProfileModule) },
  { path: '', loadChildren: () => import('./account/account.module').then(m => m.AccountModule) },
  { path: '**', pathMatch: 'full', redirectTo: '' }
];
// ======================================= //
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class IdentityRoutingModule { }
