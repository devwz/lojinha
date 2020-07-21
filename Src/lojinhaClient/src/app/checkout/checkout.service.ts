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
    apiUrl = 'http://localhost:58374/api/checkout';

    constructor(private http: HttpClient) { }

    // POST api/checkout
    checkout(checkout: Order) {
        return this.http.post<Order>(this.apiUrl, checkout, httpOptions)
    }
}