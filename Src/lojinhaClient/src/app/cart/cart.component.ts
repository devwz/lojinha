import { Component, OnInit, ɵsetCurrentInjector } from '@angular/core';

import { CartService } from './cart.service';
import { Cart, Item } from './cart';

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
  cartTotal: number;

  constructor(private cartService: CartService) { }

  ngOnInit(): void {
    this.getCart();
  }

  getTotal(): number {
    return this.cart.itemCollection.map((item) => item.price * item.unid).reduce((total, price) => total + price);
  }

  getCart(): void {
    this.cartService.getCart()
      .subscribe(cart => {
        this.cart = cart;
        this.cartTotal = this.getTotal();
      });
  }

  addOrSubtract(item: Item, unid: number): void {

    if (item.unid <= 0 && unid < 1)
    {
      return;
    }

    item.unid += unid;

    this.cartService.add(item)
      .subscribe(cart => {
        this.cart = cart;
        this.cartTotal = this.getTotal();
      });
  }

  delete(item: Item): void {
    this.cartService.delete(item)
      .subscribe(cart => {
        this.cart = cart;
        this.cartTotal = this.getTotal();
      })
  }
}
