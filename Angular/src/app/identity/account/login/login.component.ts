import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormService } from '@common/components/data-form/data-form.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  // ======================================= //
  constructor(private http: HttpClient, private form: FormService) { }
  // ======================================= //
  ngOnInit() { }
  // ======================================= //
  public login() {
    this.http.get('http://localhost:5000/api/account', {headers: {'Content-Type': 'application/json'}})
      .toPromise()
      .then((result) => confirm('You Sure?'));
  }
}
