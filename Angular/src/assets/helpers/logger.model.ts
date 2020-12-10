import { LogScope } from '@assets/enums/log.scope.enum'
import { Guid } from 'guid-ts';

export interface ILoggerModel {
  message?: string;
  descriptor?: any;
  name?: any;
  scope?: LogScope;
  target?: any;
  items?: { [item: string]: any };
}
export class LoggerModel {
  // ======================================= //
  public uid: string;
  public createdAt: number;
  public scope: LogScope;
  public caller: string;
  public items: { [item: string]: any };
  public description: string;
  public class: string;
  public source: string;
  // ======================================= //
  constructor(args?: ILoggerModel) {
    this.createdAt = new Date().valueOf();
    this.uid = Guid.newGuid().toString().split('-')[0];
    // ======================================= //
    Object.keys(args)
      .forEach(key => this[key] = args[key] );
  }
  // ======================================= //
}
