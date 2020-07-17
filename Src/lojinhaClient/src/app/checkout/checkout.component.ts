import { Component, OnInit } from '@angular/core';
import { CartService } from '../cart/cart.service';
import { Cart } from '../cart/cart';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styles: [
  ],
  providers: [ CartService ]
})
export class CheckoutComponent implements OnInit {
  cart: Cart;
  itemCollectionLength: number = 0;

  constructor(private cartService: CartService) { }

  ngOnInit(): void {
    this.getCart();
  }

  getCart(): void {
    this.cartService.getCart()
      .subscribe(cart => {
        this.cart = cart;
      })
  }

}
