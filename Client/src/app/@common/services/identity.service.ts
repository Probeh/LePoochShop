import { Subject        } from 'rxjs'
import { HttpClient     } from '@angular/common/http'
import { Injectable     } from '@angular/core'
import { Account        } from '@models/account.model'
import { Identity       } from '@models/identity.model'
import { MessageService } from '@services/message.service'
import { MessageType    } from '@enums/message.enum'

@Injectable()
export class IdentityService {
  private readonly baseUrl: string = 'http://localhost:5000';
  // ======================================= //
  public authState: boolean = false                            ;
  public identity : Identity                                   ;
  public identity$: Subject<Identity> = new Subject<Identity>();
  // ======================================= //
  constructor(private message: MessageService, private http: HttpClient) {
    this.identity$.subscribe({
      next: result => this.identity = result
    });
    this.checkIdentity();
  }
  // ======================================= //
  public userLogin(account: Account): Promise<Object> {
    return this.http
      .post(`${this.baseUrl}/auth`, account)
      .toPromise()
      .then((result) => {
        this.message.show('Success!', `Welcome ${this.identity.userName}`, MessageType.Success);
        return result;
      })
      .catch((error) => { this.message.show('Login Failure!', 'Please try again', MessageType.Error); throw error });
  }
  public userRegister(account: Account): Promise<Object> {
    return this.http
      .put(`${this.baseUrl}/auth`, account)
      .toPromise()
      .then((result) => {
        this.message.show('Success!', `Account successfully created`, MessageType.Success)
        return result;
      })
      .catch((error) => { this.message.show('Registration Failed!', '', MessageType.Error); throw error });
  }
  public userLogout(): Promise<void> {
    return Promise.resolve()
      .then(() => this.message.show('Signing Out', `Goodbye ${this.identity.userName}`, MessageType.Information))
      .then(() => this.setIdentity());
  }
  public async checkIdentity() {
    const storage: Identity = JSON.parse(localStorage.getItem('identity')) as Identity;
    this.authState = storage != null;
    if (storage && !this.identity) {
      this.identity$.next(storage);
    }
  }
  public setIdentity(identity?: Identity) {
    identity
      ? localStorage.setItem('identity', JSON.stringify(identity))
      : localStorage.removeItem('identity');
    this.authState = identity != null;
    this.identity$.next(identity);
  }
}
