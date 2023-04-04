import { Component, OnInit } from '@angular/core';
import { OrderProduct } from '../models/models';
import { OrderProductService } from '../services/order-product/order-product.service';

@Component({
  selector: 'app-order-product',
  templateUrl: './order-product.component.html',
  styleUrls: ['./order-product.component.css']
})
export class OrderProductComponent implements OnInit{
  orderprods: OrderProduct[] = [];
  orderProdToEdit?: OrderProduct; 
  visible = false;

  constructor(private orderProductService: OrderProductService) {}

  ngOnInit(): void {
    this.orderProductService.getOrderProductList()
    .subscribe((result: OrderProduct[]) => {this.orderprods = result});
  }

  updateOrderProductList(orderprods: OrderProduct[]) {
    this.orderprods = orderprods;
  }

  initNewOrder() {
    this.orderProdToEdit = new OrderProduct();
  }

  editOrderProduct(orderprod: OrderProduct){
    this.orderProdToEdit = orderprod;
  }

  toggleCollapse(): void {
    this.visible = !this.visible;
  }
}
