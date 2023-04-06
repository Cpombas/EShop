import { Component, OnInit } from '@angular/core';
import { Product } from '../models/models';
import { CartService } from '../services/cart/cart.service';


@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  products: Product[] = [];

  constructor(private cartService: CartService) { }

  ngOnInit(): void {
    this.products = this.cartService.getCartProducts();
  }

  getTotalPrice(): number {
    let total = 0;
    for (let product of this.products) {
      total += product.price || 0;
    }
    return total;
  }

  removeProduct(productId: number): void {
    this.cartService.removeProduct(productId);
    this.products = this.cartService.getCartProducts();
  }

  clearCart(): void {
    this.cartService.clearCart();
    this.products = [];
  }
}
