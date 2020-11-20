import { Component } from '@angular/core';
import { CookiePolicyService } from './cart/cookiePolicy.service';

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
  title = 'marketClient';
  showAlert: boolean;

  constructor(
    private cookiePolicyService: CookiePolicyService
  ) { }

  ngOnInit(): void {
    this.verifyCookieCache();
  }

  verifyCookieCache(): void {
    let cookieString = this.getCookie(".AspNet.Consent");
    if (cookieString == "")
    {
      this.showAlert = true;
    }
  }

  getCookie(cookieName: string): string {
    let name = cookieName + "=";
    let decodedCookie = decodeURIComponent(document.cookie);
    let cookieCollection = decodedCookie.split(';');
    
    for (let i = 0; i < cookieCollection.length; i++) {
      let cookie = cookieCollection[i];
      while (cookie.charAt(0) == ' ') {
        cookie = cookie.substr(1);
      }
      if (cookie.indexOf(name) == 0) {
        return cookie.substr(name.length, cookie.length);
      }
    }
    return "";
  }

  acceptCookiePolicy(): void {
    /*
    this.cookiePolicyService.acceptCookiePolicy()
      .subscribe(cookie => {
        document.cookie = cookie;
      });
    */
   document.cookie = ".AspNet.Consent=yes; expires=Fri, 06 Aug 2021 03:47:31 GMT; path=/; SameSite=Strict";
  }
}