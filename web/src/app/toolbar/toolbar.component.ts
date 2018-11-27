import { Component, OnInit } from '@angular/core';
import { AdalService } from 'adal-angular4';
import { environment } from '../../environments/environment'

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.css']
})
export class ToolbarComponent implements OnInit {

  constructor(private auth: AdalService) {
    auth.init(environment.config);
  }

  ngOnInit() {
    this.auth.handleWindowCallback();

    console.log(this.auth.userInfo);
  }

  get authenticated(): boolean {

    return this.auth.userInfo.authenticated;
  }

  logon() {
    this.auth.login();
  }

  logout() {
    this.auth.logOut();
  }
}
