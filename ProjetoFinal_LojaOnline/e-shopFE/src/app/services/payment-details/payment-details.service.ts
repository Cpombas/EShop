import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Payment } from 'src/app/models/models';

@Injectable({
  providedIn: 'root'
})
export class PaymentDetailsService {

  private baseUrl = "https://localhost:7004/api/PaymentDetail";

  constructor(private httpClient: HttpClient) { }

  public submitPaymentDetails(payment: Payment): Observable<Payment> {
    return this.httpClient.post<Payment>(`${this.baseUrl}`, payment);
  }
}