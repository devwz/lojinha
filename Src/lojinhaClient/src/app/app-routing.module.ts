import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CheckoutComponent } from './checkout/checkout.component';
import { ProductComponent } from './product/product.component';
import { ProductCatalogComponent } from './product/index/index.component';
import { ProductDetailComponent } from './product/detail/detail.component';

const routes: Routes = [
  {
    path: '', component: ProductComponent,
    children: [
      { path: '', component: ProductCatalogComponent }
    ]
  },
  {
    path: 'product', component: ProductComponent,
    children: [
      { path: '', component: ProductCatalogComponent },
      { path: ':id', component: ProductDetailComponent }
    ]
  },
  {
    path: 'checkout', component: CheckoutComponent,
    children: [
      { path: ':id', component: CheckoutComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
