import { Injectable } from '@angular/core';
import { Product } from 'src/app/models/models';


@Injectable({
  providedIn: 'root'
})
export class CartService {

  private cart: Product[] = [];

  constructor() { }

  addProduct(product: Product): void {
    this.cart.push(product);
  }

  removeProduct(productId: number): void {
    this.cart = this.cart.filter(product => product.productId !== productId);
  }

  getCartProducts(): Product[] {
    return this.cart;
  }

  clearCart(): void {
    this.cart = [];
  }
}