import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Category } from '../models/models';
import { CategoryService } from '../services/category/category.service';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
import { RoleService } from '../services/role/role.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit{
  categories: Category[] = [];
  categoryToEdit?: Category; 
  visible = false;

  constructor(private categoryService: CategoryService, private authService: AuthService, 
    private router: Router, private roleService: RoleService) {}

  ngOnInit(): void {
    this.categoryService.getCategoryList()
    .subscribe((result: Category[]) => {this.categories = result});
  }

  updateCategoryList(categories: Category[]) {
    this.categories = categories;
  }

  initNewCategory() {
    this.categoryToEdit = new Category();
  }

  editCategory(category: Category){
    this.categoryToEdit = category;
  }

  toggleCollapse(): void {
    this.visible = !this.visible;
  }

  isAdmin(): boolean {
    return this.roleService.hasRole('Admin');
  }

  isManager(): boolean {
    return this.roleService.hasRole('Manager');
  }
}
