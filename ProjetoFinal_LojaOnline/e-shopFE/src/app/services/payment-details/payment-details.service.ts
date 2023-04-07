import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Payment } from 'src/app/models/models';

@Injectable({
  providedIn: 'root'
})
export class PaymentDetailsService {

  private paymentUrl = '/api/payments'; // replace with your backend API endpoint for payments

  constructor(private http: HttpClient) { }

  createPayment(payment: Payment): Observable<Payment> {
    return this.http.post<Payment>(this.paymentUrl, payment);
  }

}