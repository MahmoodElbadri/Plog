import { Component } from '@angular/core';
import {NgForm} from "@angular/forms";
import {AddCategoryRequest} from "../models/add-category-request-model";
import {CategoryService} from "../services/category.service";

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent {
  category: AddCategoryRequest;
  constructor(private categoryService: CategoryService) {
    this.category = {
      name: '',
      urlHandle: ''
    };
  }

  onFormSubmit() {
    this.categoryService.addCategory(this.category).subscribe({
      next: (response)=>{
        console.log("Category added successfully");
      },
      error: (error)=>{
        console.log("Category added failed");
      },
      complete: ()=>{
        console.log("Category added completed");
      }
    });
  }
}
