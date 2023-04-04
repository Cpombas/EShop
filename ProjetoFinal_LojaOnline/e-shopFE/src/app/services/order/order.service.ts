import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from 'src/app/models/models';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private baseUrl = "https://localhost:7004/api/Orders/ActiveOrders"

  constructor(private httpClient: HttpClient) { }

  public getOrderList(): Observable<Order[]> {
    return this.httpClient.get<Order[]>(`${this.baseUrl}`);
  }

  public createOrder(order: Order) :  Observable<Order[]> {
    return this.httpClient.post<Order[]>(`${this.baseUrl}`, order);
  }

  public updateOrder(order: Order) :  Observable<Order[]> {
    return this.httpClient.put<Order[]>(`${this.baseUrl}ByOrderId?id=${order.orderId}`, order);
  }

  public deleteOrder(order: Order) :  Observable<Order[]> {
    return this.httpClient.delete<Order[]>(`${this.baseUrl}ByOrderId?id=${order.orderId}`);
  }
}