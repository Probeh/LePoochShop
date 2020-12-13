import { ModelBase } from '@models/base.model'

export class Account extends ModelBase<Account> {
  public userName: string;
  public password: string;
  public email   : string;
  // ======================================= //
  constructor(userName?: string, password?: string, email?: string) {
    super();
    this.userName = userName ?? userName;
    this.password = password ?? password;
    this.email    = email    ?? email   ;
  }
  // ======================================= //
}