import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';

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
import { RegisterComponent } from './register/register.component';
import { ProductComponent } from './product/product.component';
import { EditCategoryComponent } from './category/edit-category/edit-category.component';
import { EditProductsComponent } from './products/edit-products/edit-products.component';
import { EditUserComponent } from './user/edit-user/edit-user.component';
import { EditOrderComponent } from './order/edit-order/edit-order.component';
import { OrderProductComponent } from './order-product/order-product.component';
import { EditOrderProductComponent } from './order-product/edit-order-product/edit-order-product.component';
import { PaymentDetailsComponent } from './payment-details/payment-details.component';
import { CheckoutComponent } from './checkout/checkout.component';



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
    RegisterComponent,
    ProductComponent,
    EditCategoryComponent,
    EditProductsComponent,
    EditUserComponent,
    EditOrderComponent,
    OrderProductComponent,
    EditOrderProductComponent,
    PaymentDetailsComponent,
    CheckoutComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule,
    ReactiveFormsModule,
    ToastrModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
