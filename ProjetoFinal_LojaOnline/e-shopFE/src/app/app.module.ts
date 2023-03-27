import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductListComponent } from './products/product-list.component';
import { ProductDetailComponent } from './products/product-detail.component';
import { HomeComponent } from './home/home.component';
import { OrderComponent } from './order/order.component';
import { CartComponent } from './cart/cart.component';
import { CategoryComponent } from './category/category.component';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './login/login.component';
import { ProfileComponent } from './profile/profile.component';
import { PaymentComponent } from './payment/payment.component';
import { ProductListServiceComponent } from './services/product-list-service/product-list-service.component';
import { ProductDetailsServiceComponent } from './services/product-details-service/product-details-service.component';
import { CategoryServiceComponent } from './services/category-service/category-service.component';
import { OrderServiceComponent } from './services/order-service/order-service.component';
import { UserServiceComponent } from './services/user-service/user-service.component';
import { PaymentDetailsServiceComponent } from './services/payment-details-service/payment-details-service.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductListComponent,
    ProductDetailComponent,
    HomeComponent,
    OrderComponent,
    CartComponent,
    CategoryComponent,
    UserComponent,
    LoginComponent,
    ProfileComponent,
    PaymentComponent,
    ProductListServiceComponent,
    ProductDetailsServiceComponent,
    CategoryServiceComponent,
    OrderServiceComponent,
    UserServiceComponent,
    PaymentDetailsServiceComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
