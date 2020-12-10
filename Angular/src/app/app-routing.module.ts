import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { IdentityGuard } from '@assets/services/identity.guard'
import { HomeComponent } from '@common/sections/home/home.component'

const routes: Routes = [
  // ======================================= //
  { path: 'home', component: HomeComponent },
  { path: 'account', loadChildren: () => import('./identity/identity.module').then(m => m.IdentityModule) },
  { path: 'schedule', canActivate: [IdentityGuard], loadChildren: () => import('./schedule/schedule.module').then(m => m.ScheduleModule) },
  { path: '**', pathMatch: 'full', redirectTo: 'home' }
];
// ======================================= //
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
