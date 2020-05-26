import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class CartService {
    apiUrl = 'http://localhost:51363/api/cart/count';

    constructor(private http: HttpClient) { }

    // GET api/cart/count
    getCartItemCount() {
        return this.http.get(this.apiUrl);
    }
}