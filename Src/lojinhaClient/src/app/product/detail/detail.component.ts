import { Component, OnInit } from '@angular/core';

import { Product } from '../product';
import { ProductService } from '../product.service';

import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: [
    './detail.component.css'
  ],
  providers: [ ProductService ]
})
export class ProductDetailComponent implements OnInit {
  product: Product;

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.getProduct();
  }

  getProduct(): void {
    this.productService.getProduct(this.route.snapshot.params['id'])
    .subscribe(product => this.product = product);
  }
}
