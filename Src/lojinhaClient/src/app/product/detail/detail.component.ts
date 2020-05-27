import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Product } from '../product';
import { ProductService } from '../product.service';

import { CartService } from 'src/app/cart/cart.service';
import { CartItem } from 'src/app/cart/cart';

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

  addToCart(id: number, unid: number): void {
    this.cartService.addCartItem({ id, unid } as CartItem)
      .subscribe(() => {
        this.router.navigate(['/checkout']);
      })
  }

  getProduct(): void {
    this.productService.getProduct(this.route.snapshot.params['id'])
    .subscribe(product => this.product = product);
  }
}
