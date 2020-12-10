import { ModelBase } from '@assets/models/base.model';

export class Profile extends ModelBase<Profile> {
  public email: string;
  public firstName: string;
  public lastName: string;
  public pooch: string;
  public avatar: string;
  // ======================================= //
  constructor() { super(); }
  // ======================================= //
}
