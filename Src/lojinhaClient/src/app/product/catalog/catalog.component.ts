import { Component, OnInit } from '@angular/core';

import { Product } from '../product';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: [
    './catalog.component.css'
  ],
  providers: [ ProductService ]
})
export class ProductCatalogComponent implements OnInit {
  productCatalog: Product[];

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.getProductCatalog();
  }

  getProductCatalog(): void {
    this.productService.getProductCatalog()
      .subscribe(productCatalog => this.productCatalog = productCatalog)
  }
}
