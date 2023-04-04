import { Component, OnInit } from '@angular/core';
import { Order } from '../models/models';
import { OrderService } from '../services/order/order.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {
  orders: Order[] = [];
  orderToEdit?: Order; 
  visible = false;

  constructor(private orderService: OrderService) {}

  ngOnInit(): void {
    this.orderService.getOrderList()
    .subscribe((result: Order[]) => {this.orders = result});
  }

  updateOrderList(orders: Order[]) {
    this.orders = orders;
  }

  initNewOrder() {
    this.orderToEdit = new Order();
  }

  editOrder(order: Order){
    this.orderToEdit = order;
  }

  toggleCollapse(): void {
    this.visible = !this.visible;
  }
}
