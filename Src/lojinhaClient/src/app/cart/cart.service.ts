import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Cart, CartItem } from './cart';

const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
};

@Injectable()
export class CartService {
    apiUrl = 'http://localhost:51363/api/cart';

    constructor(private http: HttpClient) { }

    // GET api/cart/count
    getCartItemCount() {
        const url = `${this.apiUrl}/count`;
        return this.http.get(url);
    }

    // GET api/cart
    getCart() {
        return this.http.get<Cart>(this.apiUrl);
    }

    // POST api/cart
    addCartItem(cartItem: CartItem) {
        return this.http.post<CartItem>(this.apiUrl, cartItem, httpOptions)
    }
}