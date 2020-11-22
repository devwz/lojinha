import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Product } from './product';

@Injectable()
export class ProductService {
    apiUrl = 'http://127.0.0.1:31402/api/product';

    constructor(private http: HttpClient) { }

    // GET api/product
    getProductCatalog() {
        return this.http.get<Product[]>(this.apiUrl);
    }

    // GET api/product/5
    getProduct(id: number) {
        const url = `${this.apiUrl}/${id}`;
        return this.http.get<Product>(url);
    }
}