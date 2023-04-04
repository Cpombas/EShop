import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OrderProduct } from 'src/app/models/models';

@Injectable({
  providedIn: 'root'
})

export class OrderProductService {

  private baseUrl = "https://localhost:7004/api/Orders/Ordered Items"

  constructor(private httpClient: HttpClient) { }

  public getOrderProductList(): Observable<OrderProduct[]> {
    return this.httpClient.get<OrderProduct[]>(`${this.baseUrl}`);
  }

  public createOrderProduct(orderprod: OrderProduct) :  Observable<OrderProduct[]> {
    return this.httpClient.post<OrderProduct[]>(`${this.baseUrl}`, orderprod);
  }

  public updateOrderProduct(orderprod: OrderProduct) :  Observable<OrderProduct[]> {
    return this.httpClient.put<OrderProduct[]>(`${this.baseUrl}/id?id=${orderprod.orderId}`, orderprod);
  }

  public deleteOrderProduct(orderprod: OrderProduct) :  Observable<OrderProduct[]> {
    return this.httpClient.delete<OrderProduct[]>(`${this.baseUrl}/id?id=${orderprod.orderId}`);
  }
}
