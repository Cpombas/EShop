import { Injectable } from '@angular/core';
import { Product } from 'src/app/models/models';
import { HttpClient } from "@angular/common/http"
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductListService {
  private baseUrl = "https://localhost:7004/api/Products"

  constructor(private httpClient: HttpClient) { }

  public getProductList(): Observable<Product[]> {
    return this.httpClient.get<Product[]>(`${this.baseUrl}`);
  }

  public createProduct(product: Product) :  Observable<Product[]> {
    return this.httpClient.post<Product[]>(`${this.baseUrl}`, product);
  }

  public updateProduct(product: Product) :  Observable<Product[]> {
    return this.httpClient.put<Product[]>(`${this.baseUrl}/id?id=${product.productId}`, product);
  }

  public deleteProduct(product: Product) :  Observable<Product[]> {
    return this.httpClient.delete<Product[]>(`${this.baseUrl}/id?id=${product.productId}`);
  }
}