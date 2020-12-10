import { Subject } from 'rxjs'
import { Injectable } from '@angular/core'
import { AppSettings } from '@assets/helpers/app.settings'
import { IKeyValue } from '@assets/helpers/key.value'
import { ILoggerModel, LoggerModel } from '@assets/helpers/logger.model'

@Injectable()
export class LoggerService {
  private stackTrace: any = {};
  // ======================================= //
  public logScopes: IKeyValue<LoggerModel[]> = {};
  public logScopes$: IKeyValue<Subject<LoggerModel[]>> = {};
  // ======================================= //
  constructor(private config: AppSettings) { }
  // ======================================= //
  public log(args?: ILoggerModel) {
    let logItems = this.logScopes[args?.scope]
      ? this.logScopes[args?.scope]
      : new Array<LoggerModel>();

    if (!this.logScopes$[args?.scope]) {
      this.logScopes$[args?.scope] = new Subject();
      this.initialize(args.scope);
    }
    logItems.unshift(new LoggerModel(args));
    this.logScopes$[args?.scope].next(logItems);
  }

  private initialize(scope: string) {
    if (!this.config.environment.production) {
      this.logScopes$[scope]
        .subscribe({
          next: (value: LoggerModel[]) => {
            this.logScopes[scope] = value;
            this.logToConsole();
          }
        });
    }
  }
  private logToConsole() {
    console.clear();
    Object.keys(this.logScopes).forEach(key => {
      console.groupCollapsed(`%c \t\t${key} Scope => ${this.logScopes[key].length < 10 ? '0' + this.logScopes[key].length : this.logScopes[key].length} Items\t\t`, 'background: #17a2b8; color: white; text-weight: bold;')
      console.table(this.logScopes[key]);
      console.groupEnd();
    });
  }
}