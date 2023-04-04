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
import { RegisterComponent } from './register/register.component';
import { ProductComponent } from './product/product.component';
import { FormsModule } from '@angular/forms';
import { EditCategoryComponent } from './category/edit-category/edit-category.component';
import { EditProductsComponent } from './products/edit-products/edit-products.component';
import { EditUserComponent } from './user/edit-user/edit-user.component';

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
    RegisterComponent,
    ProductComponent,
    EditCategoryComponent,
    EditProductsComponent,
    EditUserComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
