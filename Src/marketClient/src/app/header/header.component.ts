import { Component, OnInit } from '@angular/core';

import { CartService } from '../cart/cart.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: [
    './header.component.css'
  ],
  providers: [ CartService ]
})
export class HeaderComponent implements OnInit {
  cartItemLength!: number;

  constructor(private cartService: CartService) { }

  ngOnInit(): void {
  }

  getCart(): void {
    this.cartService.getCart()
      .subscribe(cart => this.cartItemLength = cart.itemCollection.length);
  }
}
