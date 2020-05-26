import { Component, OnInit } from '@angular/core';

import { CartService } from './cart.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: [
    './header.component.css'
  ],
  providers: [ CartService ]
})
export class HeaderComponent implements OnInit {
  cartItemCount: Object;

  constructor(private cartService: CartService) { }

  ngOnInit(): void {
    this.getCartItemCount();
  }

  getCartItemCount() : void {
    this.cartService.getCartItemCount()
      .subscribe(cartItemCount => this.cartItemCount = cartItemCount);
  }
}
