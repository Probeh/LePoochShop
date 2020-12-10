import { CommonModule } from '@angular/common'
import { NgModule } from '@angular/core'
import { IdentityResolver } from '@assets/services/identity.resolver'
import { IdentityRoutingModule } from '@identity/identity-routing.module'
import { IdentityComponent } from '@identity/identity.component'

// ======================================= //
@NgModule({
  imports: [CommonModule, IdentityRoutingModule],
  declarations: [IdentityComponent],
  providers: [IdentityResolver],
  exports: [IdentityComponent],
})
// ======================================= //
export class IdentityModule { }
