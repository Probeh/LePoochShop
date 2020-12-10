import { CommonModule } from '@angular/common'
import { NgModule } from '@angular/core'
import { ProfileRoutingModule } from '@identity/profile/profile-routing.module'
import { ProfileComponent } from './profile.component'

@NgModule({
  imports: [CommonModule, ProfileRoutingModule],
  declarations: [ProfileComponent],
  exports: [ProfileComponent]
})
export class ProfileModule { }
