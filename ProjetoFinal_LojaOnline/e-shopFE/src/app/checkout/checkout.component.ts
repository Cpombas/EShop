import { Component, OnInit } from '@angular/core';
import { Product } from '../models/models';
import { CartService } from '../services/cart/cart.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  products: Product[] = [];

  constructor(private cartService: CartService, private router: Router) { }

  ngOnInit(): void {
    this.products = this.cartService.getCartProducts();
  }

  getTotalPrice(): number {
    return this.products.reduce((total, product) => total + (product.price * product.quantity), 0);
  }

  confirmOrder(): void {
    localStorage.setItem('cartProducts', JSON.stringify(this.products));
    this.router.navigate(['/payment']);
  }

}
