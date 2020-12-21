import { ToastrModule                              } from 'ngx-toastr'
import { CommonModule                              } from '@angular/common'
import { HTTP_INTERCEPTORS      , HttpClientModule } from '@angular/common/http'
import { ModuleWithProviders    , NgModule         } from '@angular/core'
import { BrowserAnimationsModule                   } from '@angular/platform-browser/animations'
import { Router                 , RouterModule     } from '@angular/router'
import { NavigationComponent                       } from '@common/navigation/navigation.component'
import { LogScope                                  } from '@enums/log.scope.enum'
import { AppSettings                               } from '@helpers/app.settings'
import { IdentityModule                            } from '@identity/identity.module'
import { AboutComponent                            } from '@sections/about/about.component'
import { HomeComponent                             } from '@sections/home/home.component'
import { IdentityGuard                             } from '@services/identity.guard'
import { IdentityService                           } from '@services/identity.service'
import { LoggerService                             } from '@services/logger.service'
import { MessageService                            } from '@services/message.service'
import { RequestInterceptor                        } from '@services/request.interceptor'
import { ScheduleService                           } from '@services/schedule.service'
import { StorageService                            } from '@services/storage.service'
import { TokenInterceptor                          } from '@services/token.interceptor'

// ======================================= //
const components: any[] = [AboutComponent, HomeComponent          , NavigationComponent                                                                   ];
const modules   : any[] = [CommonModule  , BrowserAnimationsModule, HttpClientModule   , IdentityModule, ToastrModule.forRoot(), RouterModule.forChild([])];
const services  : any[] = [MessageService, ScheduleService        , IdentityService    , IdentityGuard, LoggerService, StorageService                     ];
// ======================================= //
@NgModule({
  declarations:  components,
  imports     :  modules   ,
  providers   :  services  ,
  exports     : [modules   , components]
})
export class SharedModule {
  constructor(private logger: LoggerService, private router: Router) {
    this.router.events.subscribe({
      next: (value) => this.logger.log({ scope: LogScope.Router, items: { value: value } })
    });
  }

  static forRoot(config: AppSettings): ModuleWithProviders<SharedModule> {
    return {
      ngModule: SharedModule,
      providers: [
        { provide: AppSettings, useValue: config },
        services,
        { provide: HTTP_INTERCEPTORS, useClass: RequestInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true }
      ]
    }
  }
}
