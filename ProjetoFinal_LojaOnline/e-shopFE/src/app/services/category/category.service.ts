import { Injectable } from '@angular/core';
import { Category } from './category.model';
import { HttpClient } from "@angular/common/http"

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http:HttpClient) { }
  
  readonly baseUrl = "https://localhost:7004/api/Category"
  formData:Category = new Category();
  list: Category[];
  

  postCategory(){
    return this.http.post(this.baseUrl, this.formData);
  }

  putCategory(){
    return this.http.put(`${this.baseUrl}/${this.formData.categoryId}`, this.formData);
  }

  deleteCategory(id:number){
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

  refreshlist(){
    this.http.get(this.baseUrl)
    .toPromise()
    .then(res => this.list = res as Category[])
  }
}