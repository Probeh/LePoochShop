import { Component, OnInit } from '@angular/core';
import { Identity } from '@models/identity.model';
import { IdentityService } from '@services/identity.service';

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.scss']
})
export class ScheduleComponent implements OnInit {
  public account: Identity;
  constructor(private identity: IdentityService) { }

  ngOnInit() {
    this.account = this.identity.identity;
  }

  public getNames() {

  }
}
