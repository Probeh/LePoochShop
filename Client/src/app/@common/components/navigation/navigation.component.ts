import { Component, OnInit } from '@angular/core'
import { Account } from '@models/account.model'
import { DialogService } from '@services/dialog.service';
import { IdentityService } from '@services/identity.service'

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit {
  public account: Account;
  constructor(private identity: IdentityService, private dialog: DialogService) {
    this.identity.identity$.subscribe({
      next: result => {
        console.log(result)
        this.account = result;
        console.log(this.account);
      }
    });
    this.account = this.identity.identity;
  }

  ngOnInit() { }

  public showMessage() {
    this.dialog.showDialog()
  }
}
