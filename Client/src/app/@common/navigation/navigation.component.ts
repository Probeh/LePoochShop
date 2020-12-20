import { Component      , OnInit } from '@angular/core'
import { Router                  } from '@angular/router'           ;
import { Account                 } from '@models/account.model'
import { IdentityService         } from '@services/identity.service'

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit {
  public account: Account;
  constructor(private identity: IdentityService, private router: Router) {
    this.account = this.identity.identity;
    this.identity.identity$.subscribe({
      next: (result: Account) => this.account = result
    });
  }

  ngOnInit() { }

  public logout() {
    this.identity.userLogout();
    this.router.navigate(['account']);
  }
}
