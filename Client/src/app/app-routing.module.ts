import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { HomeComponent } from '@sections/home/home.component';
import { IdentityGuard } from '@services/identity.guard';

const routes: Routes = [
  // ======================================= //
  { path: 'home', component:HomeComponent },
  { path: 'schedule', canActivate: [IdentityGuard], loadChildren: () => import('./schedule/schedule.module').then(m => m.ScheduleModule) },
  { path: 'account', loadChildren: () => import('./identity/identity.module').then(m => m.IdentityModule) },
  { path: '**', pathMatch: 'full', redirectTo: '' }
];
// ======================================= //
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
