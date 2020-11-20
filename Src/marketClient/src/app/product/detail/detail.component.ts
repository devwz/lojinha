import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Product } from '../product';
import { ProductService } from '../product.service';

import { Item } from 'src/app/cart/cart';
import { CartService } from 'src/app/cart/cart.service';


@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: [
    './detail.component.css'
  ],
  providers: [
    ProductService,
    CartService
  ]
})
export class ProductDetailComponent implements OnInit {
  product!: Product;

  constructor(
    private productService: ProductService,
    private cartService: CartService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.getProduct();
  }

  addToCart(id: number, imgUrl: string, price: number, title: string, unid: number): void {
    let item: Item = { id: id, imgUrl: imgUrl, price: price, title: title, unid: unid };
    this.cartService.add(item)
      .subscribe(cart => {
        this.router.navigateByUrl('/cart');
      });
  }

  getProduct(): void {
    this.productService.getProduct(this.route.snapshot.params['id'])
      .subscribe(product => this.product = product);
  }
}
