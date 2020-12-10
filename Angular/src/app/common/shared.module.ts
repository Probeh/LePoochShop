//#region
import { CommonModule } from '@angular/common'
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http'
import { ModuleWithProviders, NgModule } from '@angular/core'
import { Router, RouterModule } from '@angular/router'
import { LogScope } from '@assets/enums/log.scope.enum'
import { AppSettings } from '@assets/helpers/app.settings'
import { ErrorService } from '@assets/services/error.service'
import { IdentityGuard } from '@assets/services/identity.guard'
import { IdentityService } from '@assets/services/identity.service'
import { LoggerService } from '@assets/services/logger.service'
import { RequestInterceptor } from '@assets/services/request.interceptor'
import { ResponseInterceptor } from '@assets/services/response.interceptor'
import { StorageService } from '@assets/services/storage.service'
import { ToastService } from '@assets/services/toast.service'
import { TokenInterceptor } from '@assets/services/token.interceptor'
import { ActionLinkComponent } from '@common/components/action-link/action-link.component'
import { DataFormModule } from '@common/components/data-form/data-form.module'
import { DataTableModule } from '@common/components/data-table/data-table.module'
import { ToastComponent } from '@common/components/data-toast/data-toast.component'
import { NavigationComponent } from '@common/components/navigation/navigation.component'
import { AboutComponent } from '@common/sections/about/about.component'
import { HomeComponent } from '@common/sections/home/home.component'
//#endregion

// ======================================= //
const modules: any[] = [CommonModule, HttpClientModule, DataFormModule, DataTableModule, RouterModule.forChild([])];
const components: any[] = [AboutComponent, ActionLinkComponent, HomeComponent, NavigationComponent, ToastComponent];
const services: any[] = [IdentityGuard, ToastService, ErrorService, LoggerService, IdentityService, StorageService];
// ======================================= //
@NgModule({
  declarations: components,
  imports: modules,
  exports: [modules, components],
  providers: services,
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
        // { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
        // { provide: HTTP_INTERCEPTORS, useClass: RequestInterceptor, multi: true },
        // { provide: HTTP_INTERCEPTORS, useClass: ResponseInterceptor, multi: true },
      ]
    }
  }
}
