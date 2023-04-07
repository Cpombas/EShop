import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Payment } from '../models/models';
import { PaymentDetailsService } from '../services/payment-details/payment-details.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-payment-details',
  templateUrl: './payment-details.component.html',
  styleUrls: ['./payment-details.component.css']
})
export class PaymentDetailsComponent {
  payment: Payment = new Payment();

  constructor() { } //private paymentService: PaymentDetailsService, private toastr: ToastrService, private route: Router

  ngOnInit(): void {
  }

  // onSubmit(): void {
  //   this.paymentService.createPayment(this.payment).subscribe(
  //     response => {
  //       console.log(response);
  //       this.toastr.success('Payment processed successfully!', 'Success');
  //       this.route.navigate(['home']);
  //     },
  //     error => {
  //       console.log(error);
  //       this.toastr.error('An error occurred while processing payment.', 'Error');
  //       this.route.navigate(['/payment-details']);
  //     }
  //   );
  // }

}
