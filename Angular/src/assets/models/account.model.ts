import { ModelBase } from '@assets/models/base.model'

export class Account extends ModelBase<Account> {
  public userName: string;
  public password: string;
  // ======================================= //
  constructor(userName?: string, password?: string) {
    super();
    this.userName = userName ?? userName;
    this.password = password ?? password;
  }
  // ======================================= //
}