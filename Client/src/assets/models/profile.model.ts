import { ModelBase } from '@models/base.model';

export class Profile extends ModelBase<Profile> {
  public email    : string;
  public firstName: string;
  public lastName : string;
  public pooch    : string;
  // ======================================= //
  constructor() { super(); }
  // ======================================= //
}
