import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Product } from '../product';
import { ProductService } from '../product.service';

import { CartItem } from 'src/app/cart/cart';
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
  product: Product;

  constructor(
    private productService: ProductService,
    private cartService: CartService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.getProduct();
  }

  addToCart(id: number, imgUrl: string, price: number, title: string, unit: number): void {
    let cartItem: CartItem = { id: id, imgUrl: imgUrl, price: price, title: title, unit: unit };
    this.cartService.addCartItem(cartItem)
      .subscribe(cart => {
        this.router.navigate(['/cart']);
      });
  }

  getProduct(): void {
    this.productService.getProduct(this.route.snapshot.params['id'])
      .subscribe(product => this.product = product);
  }
}
