import { Component, OnInit } from '@angular/core';
import { Product } from '../models/models';
import { ProductListService } from '../services/products/products-list.service';
import { CartService } from '../services/cart/cart.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit{
  products: Product[] = [];
  productToEdit?: Product; 
  visible = false;

  constructor(private productListService: ProductListService, private cartService: CartService) {}

  ngOnInit(): void {
    this.productListService.getProductList()
    .subscribe((result: Product[]) => {this.products = result});
  }

  updateProductList(products: Product[]) {
    this.products = products;
  }

  initNewProduct() {
    this.productToEdit = new Product();
  }

  editProduct(product: Product){
    this.productToEdit = product;
  }

  toggleCollapse(): void {
    this.visible = !this.visible;
  }
  
  addProductToCart(product: Product) {
    this.productToEdit = product;
    this.productToEdit.quantity += 1;
    this.cartService.addProduct(this.productToEdit);
  }
}
