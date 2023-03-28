import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Category } from '../services/category/category.model';
import { CategoryService } from '../services/category/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit{
  constructor(public service: CategoryService,
    private toastr: ToastrService) {}

  ngOnInit(): void {
    this.service.refreshlist();
  }

  populateForm(selectedRecord: Category){
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id:number){
    if(confirm('Are you sure to delete this record?'))
    {
      this.service.deleteCategory(id)
      .subscribe({
        next: (res) => {
          this.service.refreshlist();
          this.toastr.error("Deleted successfully", 'Payment Detail Register')
        },
        error: (err) => {console.log(err)}
      })
    }
  }
}
