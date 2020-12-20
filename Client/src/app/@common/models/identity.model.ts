import { Account } from '@models/account.model'

export class Identity extends Account {
  public token: string;
  // ======================================= //
  constructor(username: string, email: string, token: string) {
    super(username, null, email);
    this.token = token;
  }
}