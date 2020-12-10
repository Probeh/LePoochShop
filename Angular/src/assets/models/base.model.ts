
export interface IModelBase {
  id?: number;
  name?: string;
  description?: string;
  isActive?: boolean;
  isDefault?: boolean;
}
export class ModelBase<T extends ModelBase<T>> {
  // ======================================= //
  public id: number;
  public created: number;
  public description: string;
  public isActive: boolean;
  public isDefault: boolean;
  public name: string;
  // ======================================= //
  constructor(args?: IModelBase) {
    args ?? Object.keys(this)
      .forEach(key => this[key] = this[key] ?? args[key]);
  }
  // ======================================= //
}