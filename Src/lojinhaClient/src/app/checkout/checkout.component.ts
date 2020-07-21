import { Component, OnInit, Input } from '@angular/core';
import { CartService } from '../cart/cart.service';
import { Order } from '../order/order';
import { Cart } from '../cart/cart';
import { CheckoutService } from './checkout.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: [
  ],
  providers: [ CartService, CheckoutService ]
})
export class CheckoutComponent implements OnInit {
  cart: Cart;
  order: Order;
  cartTotal: number = 0;

  constructor(
    private cartService: CartService,
    private checkoutService: CheckoutService) { }

  ngOnInit(): void {
    this.getCart();
  }

  getCart(): void {
    this.cartService.getCart()
      .subscribe(cart => {
        this.cart = cart;
        this.cartTotal = this.cart.itemCollection.map((item) => item.price * item.unid).reduce((total, price) => total + price);
      })
  }

  checkout(): void {

    this.order = {
      cart: this.cart,
      client: {
        name: "Fulano", 
        surname: "de Tal",
        email: "fulanodetal@outlook.com.br",
        address: {
          addressLine: "Rua Fulano de Tal, 0 - Americana",
          countryRegion: "Brasil",
          postalCode: "00000-000",
          stateProvince: "SP"
        }
      }
    };

    this.checkoutService.checkout(this.order)
      .subscribe(order => {
        this.order = order;
      })
  }
}
