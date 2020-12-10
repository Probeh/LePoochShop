import { Subject } from 'rxjs'
import { tap } from 'rxjs/operators'
import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Context } from '@assets/enums/context.enum'
import { Provider } from '@assets/enums/providers.enum'
import { Account } from '@assets/models/account.model'
import { Identity } from '@assets/models/identity.model'
import { StorageService } from '@assets/services/storage.service'

@Injectable()
export class IdentityService {
  // ======================================= //
  public authState: boolean = false;
  public authState$: Subject<boolean> = new Subject<boolean>();
  public identity: Identity;
  public identity$: Subject<Identity> = new Subject<Identity>();
  // ======================================= //
  constructor(private storage: StorageService, private http: HttpClient) {

    this.authState$.subscribe({
      next: result => this.authState = result
    });
    this.identity$.subscribe({
      next: result => this.identity = result
    });
    this.checkStorageForToken();
  }
  // ======================================= //
  public async checkStorageForToken() {
    const result = await this.storage
      .getStorage<Identity>(Context.Identity);
    if (result[0])
      this.identity$.next(result[0]);

    this.authState$.next(result[0] != null);
  }
  public authenticateUser(account: Account) {
    return this.http.post(`${Provider.Server}/account`, account)
      .pipe(tap(result => console.log(result)));
  }
}
