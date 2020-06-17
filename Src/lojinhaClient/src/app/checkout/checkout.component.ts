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
  cart: Cart;

  constructor(private cartService: CartService) { }

  ngOnInit(): void {
    this.getCart();
  }

  getCart(): void {
    this.cartService.getCart()
      .subscribe(cart => this.cart = cart);
  }
}
