import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'
import { environment as env } from '@env/environment'
import { SharedModule } from '@common/shared.module'
import { AppRoutingModule } from './app-routing.module'
import { AppComponent } from './app.component'

@NgModule({
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule.forRoot({ environment: env })
  ],
  declarations: [AppComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
