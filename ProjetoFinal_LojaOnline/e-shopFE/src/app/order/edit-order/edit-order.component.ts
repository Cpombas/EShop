import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Order } from 'src/app/models/models';
import { OrderService } from 'src/app/services/order/order.service';

@Component({
  selector: 'app-edit-order',
  templateUrl: './edit-order.component.html',
  styleUrls: ['./edit-order.component.css']
})
export class EditOrderComponent {
  @Input() order?: Order;
  @Output() orderUpdated = new EventEmitter<Order[]>();

  constructor(private orderService: OrderService) { }

  ngOnInit(): void {
    
  }

  createOrder(order: Order) {
    this.orderService
    .createOrder(order)
    .subscribe({
      next: (res) => {
        (orders: Order[]) => this.orderUpdated.emit(orders)
      },
      error: (err) => {console.log(err);}
    });
  }

  updateOrder(order: Order) {
    this.orderService
    .updateOrder(order)
    .subscribe({
      next: (res) => {
        (orders: Order[]) => this.orderUpdated.emit(orders)
      },
      error: (err) => {console.log(err);}
    });
  }

  deleteOrder(order: Order) {
    this.orderService
    .deleteOrder(order)
    .subscribe({
      next: (res) => {
        (orders: Order[]) => this.orderUpdated.emit(orders)
      },
      error: (err) => {console.log(err);}
    });
  }
}
