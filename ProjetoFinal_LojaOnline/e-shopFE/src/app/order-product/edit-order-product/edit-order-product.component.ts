import { Component, EventEmitter, Input, Output } from '@angular/core';
import { OrderProduct } from 'src/app/models/models';
import { OrderProductService } from 'src/app/services/order-product/order-product.service';

@Component({
  selector: 'app-edit-order-product',
  templateUrl: './edit-order-product.component.html',
  styleUrls: ['./edit-order-product.component.css']
})
export class EditOrderProductComponent {
  @Input() orderprod?: OrderProduct;
  @Output() orderProdUpdated = new EventEmitter<OrderProduct[]>();

  constructor(private orderProductService: OrderProductService) { }

  ngOnInit(): void {
    
  }

  createOrderProduct(orderprod: OrderProduct) {
    this.orderProductService
    .createOrderProduct([orderprod])
    .subscribe({
      next: (res) => {
        (ordersprods: OrderProduct[]) => this.orderProdUpdated.emit(ordersprods)
      },
      error: (err) => {console.log(err);}
    });
  }

  updateOrderProduct(orderprod: OrderProduct) {
    this.orderProductService
    .updateOrderProduct(orderprod)
    .subscribe({
      next: (res) => {
        (ordersprods: OrderProduct[]) => this.orderProdUpdated.emit(ordersprods)
      },
      error: (err) => {console.log(err);}
    });
  }

  deleteOrderProduct(orderprod: OrderProduct) {
    this.orderProductService
    .deleteOrderProduct(orderprod)
    .subscribe({
      next: (res) => {
        (ordersprods: OrderProduct[]) => this.orderProdUpdated.emit(ordersprods)
      },
      error: (err) => {console.log(err);}
    });
  }
}
