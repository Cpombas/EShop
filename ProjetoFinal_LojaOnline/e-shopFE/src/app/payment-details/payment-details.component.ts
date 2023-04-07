import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Order, OrderProduct, PaymentDetails } from '../models/models';
import { PaymentDetailsService } from '../services/payment-details/payment-details.service';
import { OrderService } from '../services/order/order.service';
import { OrderProductService } from '../services/order-product/order-product.service';

@Component({
  selector: 'app-payment-details',
  templateUrl: './payment-details.component.html',
  styleUrls: ['./payment-details.component.css']
})
export class PaymentDetailsComponent implements OnInit {

  paymentDetailsForm: FormGroup = this.formBuilder.group({
    cardOwnerName: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    address: ['', Validators.required],
    cardNumber: ['', Validators.required],
    expirationDate: ['', Validators.required],
    securityCode: ['', Validators.required]
  });

  paymentDetails: PaymentDetails = {
    paymentId: 0,
    userId: 0,
    cardOwnerName: '',
    email: '',
    address: '',
    cardNumber: 0,
    expirationDate: 0,
    securityCode: 0
};

  constructor(private formBuilder: FormBuilder,
              private paymentDetailsService: PaymentDetailsService,
              private orderService: OrderService,
              private orderProductService: OrderProductService,
              private router: Router) { }

  ngOnInit(): void {
    this.paymentDetailsForm = this.formBuilder.group({
      cardOwnerName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      address: ['', Validators.required],
      cardNumber: ['', Validators.required],
      expirationDate: ['', Validators.required],
      securityCode: ['', Validators.required]
    });
  }

  onSubmit(): void {
    this.paymentDetails = this.paymentDetailsForm.value;
    this.paymentDetailsService.addPaymentDetails(this.paymentDetails).subscribe(() => {
      console.log('Payment details added successfully');
    });
  }

  onFinishOrder(): void {

    const order: Order = {
      orderId: 0, 
      userId: 0, 
      dateOfOrder: new Date(),
      dateOfDelivery: undefined, 
      totalPrice: 0, 
      orderStatus: 'Pending' 
    };

    
    this.orderService.createOrder(order).subscribe((newOrder: Order[]) => {
      console.log('Order created successfully:', newOrder);

      
      const orderProducts: OrderProduct[] = [];

      // TODO: Replace this with the actual cart data
      const cartData = [{productId: 1, quantity: 2}, {productId: 2, quantity: 1}];

      cartData.forEach((item) => {
        const orderProduct: OrderProduct = {
          orderProductId: 0, 
          orderId: newOrder[0].orderId,
          productId: item.productId,
          quantity: item.quantity,
          price: 0 
        };
        orderProducts.push(orderProduct);
      });

      this.orderProductService.createOrderProduct(orderProducts).subscribe(() => {
        console.log('Order products created successfully');
        this.router.navigate(['/confirmation']);
      });
    });
  }

}
