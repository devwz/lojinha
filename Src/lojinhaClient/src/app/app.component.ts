import { Component } from '@angular/core';
import { CookiePolicyService } from './cart/cookiePolicy.service';
import { Cookie } from './cart/cookie';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: [
    './app.component.css'
  ],
  providers: [
    CookiePolicyService
  ]
})
export class AppComponent {
  title = 'lojinhaClient';
  showAlert: boolean;

  constructor(
    private cookiePolicyService: CookiePolicyService
  ) { }

  ngOnInit(): void {
    this.checkShowAlert();
  }

  checkShowAlert(): void {
    this.cookiePolicyService.checkShowAlert()
      .subscribe(showAlert => this.showAlert = showAlert);
  }

  acceptCookiePolicy(): void {
    this.cookiePolicyService.acceptCookiePolicy()
      .subscribe(cookie => document.cookie = cookie);
  }

}