import { BrowserModule           } from '@angular/platform-browser';
import { NgModule                } from '@angular/core'            ;
import { AppRoutingModule        } from './app-routing.module'     ;
import { AppComponent            } from './app.component'          ;
import { SharedModule            } from '@common/shared.module'    ;
import { environment as env      } from '@env/environment'

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
