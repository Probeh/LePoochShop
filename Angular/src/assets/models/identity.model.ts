import { Account } from '@assets/models/account.model'
export class Identity extends Account {
  private _token: string;
  // ======================================= //
  constructor() { super(); }
  // ======================================= //
  public get token() { return this._token; };
  public set token(value: string) { this._token = value; }
}