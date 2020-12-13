import { Account } from '@models/account.model'
export class Identity extends Account {
  private _token: string;
  // ======================================= //
  constructor(username: string, email: string, token: string) {
    super(username, null, email);
    this._token = token;
  }
  // ======================================= //
  public get token() { return this._token; };
  public set token(value: string) { this._token = value; }
}