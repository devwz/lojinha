import { Component, OnInit } from '@angular/core';

import { CartService } from './cart.service';
import { Cart, CartItem } from './cart';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: [
    './cart.component.css'
  ],
  providers: [ CartService ]
})
export class CartComponent implements OnInit {
  cart: Cart;

  constructor(private cartService: CartService) { }

  ngOnInit(): void {
    this.getCart();
  }

  getCart(): void {
    this.cartService.getCart()
      .subscribe(cart => this.cart = cart);
  }

  addOrSubtractUnit(cartItem: CartItem, unit: number): void {
    cartItem.unit += unit;
    this.cartService.addCartItem(cartItem)
      .subscribe(cart => this.cart = cart);
  }
}
