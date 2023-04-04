import { Injectable } from '@angular/core';
import { Category } from 'src/app/models/models';
import { HttpClient } from "@angular/common/http"
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private baseUrl = "https://localhost:7004/api/Category"

  constructor(private httpClient: HttpClient) { }

  public getCategoryList(): Observable<Category[]> {
    return this.httpClient.get<Category[]>(`${this.baseUrl}`);
  }

  public createCategory(category: Category) :  Observable<Category[]> {
    return this.httpClient.post<Category[]>(`${this.baseUrl}`, category);
  }

  public updateCategory(category: Category) :  Observable<Category[]> {
    return this.httpClient.put<Category[]>(`${this.baseUrl}/id?id=${category.categoryId}`, category);
  }

  public deleteCategory(category: Category) :  Observable<Category[]> {
    return this.httpClient.delete<Category[]>(`${this.baseUrl}/id?id=${category.categoryId}`);
  }
}