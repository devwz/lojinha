import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Cart, Item } from './cart';
import { Order } from '../order/order';

const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    }),
    withCredentials: true
};

@Injectable()
export class CartService {
    // apiUrl = 'http://localhost:31404/api/cart'; // kubectl
    apiUrl = 'http://localhost:51363/api/cart';

    constructor(private http: HttpClient) { }

    // GET api/cart
    getCart() {
        return this.http.get<Cart>(this.apiUrl, httpOptions);
    }

    // DELETE api/cart
    deleteCart(id: number) {
        const url = `${this.apiUrl}/${id}`;
        return this.http.delete<Order>(url, httpOptions);
    }

    // POST api/cart/item/add
    add(item: Item) {
        const url = this.apiUrl.concat('/item/add');
        return this.http.post<Cart>(url, item, httpOptions)
    }

    // POST api/cart/item/delete
    delete(item: Item) {
        const url = this.apiUrl.concat('/item/delete');
        return this.http.post<Cart>(url, item, httpOptions)
    }
}