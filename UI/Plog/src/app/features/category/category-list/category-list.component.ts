import {Component, OnInit} from '@angular/core';
import {CategoryService} from "../services/category.service";
import {category} from "../models/category.model";

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit{
  categories: category[] = [];
constructor(private categoryService: CategoryService) {

}

  ngOnInit(): void {
        this.categoryService.getCategories().subscribe({
          next:(categoriesResponses)=>{
            this.categories = categoriesResponses;
          },
          error:(error)=>{
            console.log(error);
          }
        });
    }
}
