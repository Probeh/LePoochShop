import { CommonModule                          } from '@angular/common'
import { HTTP_INTERCEPTORS  , HttpClientModule } from '@angular/common/http'
import { ModuleWithProviders, NgModule         } from '@angular/core'
import { Router             , RouterModule     } from '@angular/router'
import { DialogComponent                       } from '@components/dialog/dialog.component'
import { NavigationComponent                   } from '@components/navigation/navigation.component'
import { LogScope                              } from '@enums/log.scope.enum'
import { AppSettings                           } from '@helpers/app.settings'
import { AboutComponent                        } from '@sections/about/about.component'
import { HomeComponent                         } from '@sections/home/home.component'
import { DialogService                         } from '@services/dialog.service'
import { ErrorService                          } from '@services/error.service'
import { IdentityGuard                         } from '@services/identity.guard'
import { IdentityService                       } from '@services/identity.service'
import { LoggerService                         } from '@services/logger.service'
import { RequestInterceptor                    } from '@services/request.interceptor'
import { StorageService                        } from '@services/storage.service'
import { TokenInterceptor                      } from '@services/token.interceptor'

// ======================================= //
const components: any[] = [AboutComponent, HomeComponent   , NavigationComponent, DialogComponent                               ];
const modules   : any[] = [CommonModule  , HttpClientModule, RouterModule       . forChild       ([])                           ];
const services  : any[] = [IdentityGuard , ErrorService    , LoggerService      , IdentityService, StorageService, DialogService];
// ======================================= //
@NgModule({
  declarations:  components,
  imports     :  modules   ,
  exports     : [modules   , components],
  providers   :  services  ,
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
