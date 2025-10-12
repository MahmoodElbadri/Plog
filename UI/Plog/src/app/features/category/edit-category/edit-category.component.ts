import {Component, OnDestroy, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {Subscription} from "rxjs";
import {category} from "../models/category.model";
import {CategoryService} from "../services/category.service";
import {UpdateCategoryRequest} from "../models/update-category-request";

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.css']
})
export class EditCategoryComponent implements OnInit, OnDestroy {

  id: string | null = null;
  paramSubscription?: Subscription;
  categorySubscription?: Subscription;
  category: category | null = null;

  constructor(private route: ActivatedRoute,
              private catService: CategoryService,
              private router: Router) {
  }


  ngOnInit(): void {
    this.paramSubscription = this.route.paramMap.subscribe({
      next: (params) => {
        this.id = params.get('id');
        if (this.id) {
          this.catService.getCategoryByID(this.id).subscribe({
            next: (response) => {
              this.category = response;
            }
          });
        }
      },
      error: (error) => {
        console.log(error);
      }
    });
  }
  onFormSubmit() {
    const updateCatRequest: UpdateCategoryRequest = {
      name: this.category?.name ?? '',
      urlHandle: this.category?.urlHandle ?? ''
    };
    if(this.id) {
      this.categorySubscription =  this.catService.updateCategory(this.id, updateCatRequest).subscribe({
        next: ()=>{
          this.router.navigateByUrl(`/admin/categories`);
        },
        error: (error)=>{
          console.log(error);
        },
        complete: ()=>{
          console.log("Category updated completed");
        }
      });
    }
  }
  onCancel() {
    this.router.navigateByUrl(`/admin/categories`);
  }

  ngOnDestroy(): void {
    this.paramSubscription?.unsubscribe();
    this.categorySubscription?.unsubscribe();
  }

}
