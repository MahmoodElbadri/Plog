import {Component, OnDestroy, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {Observable, Subscription} from "rxjs";
import {BlogPostService} from "../services/blog-post.service";
import {BlogPost} from "../models/Blog-Post-Model";
import {CategoryService} from "../../category/services/category.service";
import {category} from "../../category/models/category.model";

@Component({
  selector: 'app-edit-blogpost',
  templateUrl: './edit-blogpost.component.html',
  styleUrls: ['./edit-blogpost.component.css']
})
export class EditBlogpostComponent implements OnInit, OnDestroy {
  id: string | null = null;
  routeSubscription?: Subscription;
  model?: BlogPost;
  blogPostSubscription?: Subscription;
  categories$?: Observable<category[]>;
  protected readonly Math = Math;
  selectedCategories?: string[];

  constructor(private route: ActivatedRoute,
              private blogPostService: BlogPostService,
              private catService: CategoryService) {
  }

  onFormSubmit() {

  }


  ngOnInit(): void {
    this.categories$ = this.catService.getCategories();
    this.routeSubscription = this.route.paramMap.subscribe(params => {
      this.id = params.get('id');
      if (this.id) {
        this.blogPostSubscription = this.blogPostService.getBlogPostByID(this.id).subscribe({
          next: (response) => {
            this.model = response;
            this.selectedCategories = this.model.categories.map(x => x.id)
          },
          error: (err) => {
            console.log(err);
          },
          complete: () => {
            console.log("Blog post retrieved successfully");
          }
        })
      }
    })
  }

  ngOnDestroy(): void {
    this.routeSubscription?.unsubscribe();
    this.blogPostSubscription?.unsubscribe();
  }

}
