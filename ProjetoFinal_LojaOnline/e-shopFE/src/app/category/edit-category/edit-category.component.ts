import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Category } from 'src/app/models/models';
import { CategoryService } from 'src/app/services/category/category.service';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.css']
})
export class EditCategoryComponent implements OnInit {
  @Input() category?: Category;
  @Output() categoryUpdated = new EventEmitter<Category[]>();

  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {
    
  }

  createCategory(category: Category) {
    this.categoryService
    .createCategory(category)
    .subscribe({
      next: (res) => {
        (categories: Category[]) => this.categoryUpdated.emit(categories)
      },
      error: (err) => {console.log(err);}
    });
  }

  updateCategory(category: Category) {
    this.categoryService
    .updateCategory(category)
    .subscribe({
      next: (res) => {
        (categories: Category[]) => this.categoryUpdated.emit(categories)
      },
      error: (err) => {console.log(err);}
    });
  }

  deleteCategory(category: Category) {
    this.categoryService
    .deleteCategory(category)
    .subscribe({
      next: (res) => {
        (categories: Category[]) => this.categoryUpdated.emit(categories)
      },
      error: (err) => {console.log(err);}
    });
  }
}