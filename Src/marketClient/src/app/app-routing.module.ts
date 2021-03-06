import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProductComponent } from './product/product.component';
import { ProductCatalogComponent } from './product/catalog/catalog.component';
import { ProductDetailComponent } from './product/detail/detail.component';
import { CartComponent } from './cart/cart.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { OrderComponent } from './order/order.component';

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
      { path: ':id', component: ProductDetailComponent }
    ]
  },
  {
    path: 'cart', component: CartComponent
  },
  {
    path: 'checkout', component: CheckoutComponent
  },
  {
    path: 'order', component: OrderComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
