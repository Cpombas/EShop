import { Injectable } from '@angular/core';
import { Product } from 'src/app/models/models';


@Injectable({
  providedIn: 'root'
})
export class CartService {

  private cart: Product[] = [];

  constructor() { }

  addProduct(product: Product): void {
    const existingProduct = this.cart.find(p => p.productId === product.productId);
    if (existingProduct) {
      existingProduct.quantity += 1;
    } else {
      product.quantity = 1;
      this.cart.push(product);
    }
  }

  removeProduct(productId: number): void {
    const existingProduct = this.cart.find(p => p.productId === productId);
    if (existingProduct) {
      existingProduct.quantity -= 1;
      if (existingProduct.quantity === 0) {
        const productIndex = this.cart.indexOf(existingProduct);
        this.cart.splice(productIndex, 1);
      }
    }
  }

  clearCart(): void {
    this.cart = [];
  }

  getCartProducts(): Product[] {
    return this.cart;
  }

}