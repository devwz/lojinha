import { Injectable } from '@angular/core'
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    }),
    withCredentials: true
};

@Injectable()
export class CookiePolicyService {
    apiUrl = 'http://localhost:51363/api/cookiePolicy';

    constructor(private http: HttpClient) { }

    // POST api/cookiePolicy
    checkShowAlert() {
        return this.http.get<boolean>(this.apiUrl, httpOptions);
    }

    // POST api/cookiePolicy
    acceptCookiePolicy() {
        return this.http.post<string>(this.apiUrl, null, httpOptions);
    }
    
}