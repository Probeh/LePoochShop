import { Subject } from 'rxjs'
import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Account } from '@models/account.model'
import { Identity } from '@models/identity.model'
import { StorageService } from '@services/storage.service'

@Injectable()
export class IdentityService {
  private readonly baseUrl: string = 'http://localhost:5000';
  // ======================================= //
  public authState: boolean = false;
  public identity: Identity;
  public identity$: Subject<Identity> = new Subject<Identity>();
  // ======================================= //
  constructor(private storage: StorageService, private http: HttpClient) {
    this.identity$.subscribe({
      next: result => this.identity = result
    });
    this.checkIdentity();
  }
  // ======================================= //
  public userLogin(account: Account) {
    return this.http.post(`${this.baseUrl}/auth`, account);
  }
  public userRegister(account: Account) {
    return this.http.put(`${this.baseUrl}/auth`, account);
  }
  public userLogout() {
    return this.http.post(`${this.baseUrl}/auth/logout`, {});
  }
  public async checkIdentity() {
    const storage: Identity = JSON.parse(localStorage.getItem('identity')) as Identity;
    this.authState = storage != null;
    if (storage && !this.identity) {
      this.identity$.next(storage);
    }
  }
  public setIdentity(identity: Identity) {
    localStorage.setItem('identity', JSON.stringify(identity));
    this.authState = true;
    this.identity$.next(identity);
  }
}
