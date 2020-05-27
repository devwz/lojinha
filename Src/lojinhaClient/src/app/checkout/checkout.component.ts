import { Component, OnInit } from '@angular/core';

import { CartService } from '../cart/cart.service';
import { Cart } from '../cart/cart';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: [
    './checkout.component.css'
  ],
  providers: [ CartService ]
})
export class CheckoutComponent implements OnInit {
  cartItemCount: Object;
  cart: Cart;

  constructor(private cartService: CartService) { }

  ngOnInit(): void {
    this.getCartItemCount();
    this.getCart();
  }

  getCartItemCount() : void {
    this.cartService.getCartItemCount()
      .subscribe(cartItemCount => this.cartItemCount = cartItemCount);
  }

  getCart() : void {
    this.cartService.getCart()
      .subscribe(cart => this.cart = cart);
  }
}
