import {Component, OnDestroy, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {Observable, Subscription} from "rxjs";
import {BlogPostService} from "../services/blog-post.service";
import {BlogPost} from "../models/Blog-Post-Model";
import {CategoryService} from "../../category/services/category.service";
import {category} from "../../category/models/category.model";
import {UpdateBlogPostModel} from "../models/update-blog-post-model";

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
  updateBlogPostSubscription?: Subscription;
  deleteBlogPostSubscription?: Subscription;

  constructor(private route: ActivatedRoute,
              private blogPostService: BlogPostService,
              private catService: CategoryService,
              private router: Router) {
  }

  onFormSubmit() {
    if (this.id && this.model) {
      let updateBlogPostModel: UpdateBlogPostModel = {
        title: this.model.title,
        shortDescription: this.model.shortDescription,
        featuredImageUrl: this.model.featureImageUrl,
        content: this.model.content,
        author: this.model.author,
        urlHandle: this.model.urlHandle,
        publishedDate: this.model.publishedDate,
        isVisible: this.model.isVisible,
        categories: this.selectedCategories ?? []
      }
     this.updateBlogPostSubscription = this.blogPostService.updateBlogPost(this.id,updateBlogPostModel).subscribe({
        next: ()=>{
          console.log(updateBlogPostModel)
          this.router.navigateByUrl("/admin/blog-posts");
        },
        error:(err)=>{
          console.log(err);
        },
        complete:()=>{
          console.log("Blog post updated successfully");
        }
      })
    }
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

  onDelete(){
    if(this.id){
      this.deleteBlogPostSubscription = this.blogPostService.deleteBlogPost(this.id).subscribe({
        next:()=>{
          this.router.navigateByUrl("/admin/blog-posts");
        },
        error:(err)=>{
          console.log(err);
        },
        complete:()=>{
          console.log("Blog post deleted successfully");
        }
      })
    }
  }

  ngOnDestroy(): void {
    this.routeSubscription?.unsubscribe();
    this.blogPostSubscription?.unsubscribe();
    this.updateBlogPostSubscription?.unsubscribe();
    this.deleteBlogPostSubscription?.unsubscribe();
  }

}
