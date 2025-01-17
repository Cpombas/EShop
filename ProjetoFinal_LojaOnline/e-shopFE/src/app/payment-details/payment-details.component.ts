import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OrderService } from '../services/order/order.service';
import { OrderProductService } from '../services/order-product/order-product.service';
import { PaymentDetailsService } from '../services/payment-details/payment-details.service';
import { Order, OrderProduct } from '../models/models';
//import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-payment-details',
  templateUrl: './payment-details.component.html',
  styleUrls: ['./payment-details.component.css']
})
export class PaymentDetailsComponent implements OnInit {

  payment = {
    paymentId: 0,
    userId: 0,
    cardOwnerName: '',
    email: '',
    address: '',
    cardNumber: '',
    expirationDate: '',
    securityCode: ''
  };

  products: any[] = [];

  constructor(private orderService: OrderService,
    private orderProductService: OrderProductService,
    private paymentDetailsService: PaymentDetailsService,
    private router: Router) { }
  //private toastr: ToastrService) { }

  ngOnInit(): void {
    this.products = JSON.parse(localStorage.getItem('cartProducts') || '[]');
  }

  onSubmit(): void {
    const order = new Order(); // set the user ID using the token in the local storage (has username, use getUserByName to get all, then get the id)
    order.userId = 4; // PS: Maybe add a claim to store the id
    order.dateOfOrder = new Date();
    order.totalPrice = this.products.reduce((total, product) => total + product.price, 0);
    order.orderStatus = 'Pending';

    this.orderService.createOrder(order).subscribe((createdOrders: Order[]) => {
      const createdOrder = createdOrders[0];
      //const orderProducts: OrderProduct[] = [];
      for (const product of this.products) {
        const orderProduct = new OrderProduct();
        orderProduct.orderId = createdOrder.orderId;
        orderProduct.productId = product.productId;
        orderProduct.quantity = product.quantity;
        orderProduct.price = product.price;
        //orderProducts.push(orderProduct);
        this.orderProductService.createOrderProduct(orderProduct)
      }
      //this.orderProductService.createOrderProduct(orderProducts).subscribe(() => {
      this.paymentDetailsService.submitPaymentDetails(this.payment).subscribe(() => {
        localStorage.removeItem('cartProducts');
        //this.toastr.success('Payment details submitted successfully!', 'Success');  Isn't working properly for now
        this.router.navigate(['/home']);
      });
    });
  }
}
