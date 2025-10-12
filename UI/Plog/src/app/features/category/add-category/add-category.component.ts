import {Component, OnDestroy} from '@angular/core';
import {NgForm} from "@angular/forms";
import {AddCategoryRequest} from "../models/add-category-request-model";
import {CategoryService} from "../services/category.service";
import {Subscription} from "rxjs";

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnDestroy {
  category: AddCategoryRequest;
  private addCategorySubscription?: Subscription;

  constructor(private categoryService: CategoryService) {
    this.category = {
      name: '',
      urlHandle: ''
    };
  }


  onFormSubmit() {
    this.addCategorySubscription = this.categoryService.addCategory(this.category).subscribe({
      next: (response) => {
        console.log("Category added successfully");
      },
      error: (error) => {
        console.log("Category added failed");
      },
      complete: () => {
        console.log("Category added completed");
      }
    });
  }

  ngOnDestroy(): void {
    this.addCategorySubscription?.unsubscribe();
  }
}
