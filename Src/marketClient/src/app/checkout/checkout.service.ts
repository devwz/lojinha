import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Order } from '../order/order';

const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    }),
    withCredentials: true
};

@Injectable()
export class CheckoutService {
    // apiUrl = 'http://127.0.0.1:31406/api/checkout'; // kubectl
    apiUrl = 'http://127.0.0.1:58374/api/checkout';

    constructor(private http: HttpClient) { }

    // POST api/checkout
    checkout(checkout: Order) {
        return this.http.post<Order>(this.apiUrl, checkout, httpOptions)
    }
}