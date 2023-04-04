import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Product } from 'src/app/models/models';
import { ProductListService } from 'src/app/services/products/products-list.service';

@Component({
  selector: 'app-edit-products',
  templateUrl: './edit-products.component.html',
  styleUrls: ['./edit-products.component.css']
})
export class EditProductsComponent implements OnInit{
  @Input() product?: Product;
  @Output() productUpdated = new EventEmitter<Product[]>();

  constructor(private productListService: ProductListService) { }

  ngOnInit(): void {
    
  }

  createProduct(product: Product) {
    this.productListService
    .createProduct(product)
    .subscribe({
      next: (res) => {
        (products: Product[]) => this.productUpdated.emit(products)
      },
      error: (err) => {console.log(err);}
    });
  }

  updateProduct(product: Product) {
    this.productListService
    .updateProduct(product)
    .subscribe({
      next: (res) => {
        (products: Product[]) => this.productUpdated.emit(products)
      },
      error: (err) => {console.log(err);}
    });
  }

  deleteProduct(product: Product) {
    this.productListService
    .deleteProduct(product)
    .subscribe({
      next: (res) => {
        (products: Product[]) => this.productUpdated.emit(products)
      },
      error: (err) => {console.log(err);}
    });
  }
}
