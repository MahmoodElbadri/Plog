import {Component, OnInit} from '@angular/core';
import {AddBlogPostModel} from "../models/add-blog-post-model";
import {BlogPostService} from "../services/blog-post.service";
import {Router} from "@angular/router";
import {CategoryService} from "../../category/services/category.service";
import {Observable} from "rxjs";
import {category} from "../../category/models/category.model";

@Component({
  selector: 'app-add-blog-post',
  templateUrl: './add-blog-post.component.html',
  styleUrls: ['./add-blog-post.component.css']
})
export class AddBlogPostComponent implements OnInit {
  model: AddBlogPostModel;
  categories$?: Observable<category[]>; //this what we are talking about

  constructor(
    private blogPostService: BlogPostService,
    private router: Router,
    private catService: CategoryService
  ) {
    this.model = {
      title: '',
      shortDescription: '',
      featuredImageUrl: '',
      content: '',
      author: '',
      urlHandle: '',
      publishedDate: new Date().toISOString(),
      isVisible: true,
      categories: []
    };
  }

  ngOnInit(): void {
    this.categories$ = this.catService.getCategories();
  }

  onFormSubmit() {
    this.blogPostService.addBlogPost(this.model).subscribe({
      next: () => {
        console.log(this.model)
        this.router.navigateByUrl('/admin/blog-posts');
      },
      error: (err) => {
        console.log(this.model)
        console.error('Error occurred while adding blog post:', err);
      },
      complete: () => {
        console.log('Blog post added successfully');
      }
    });
  }

  protected readonly Math = Math;
}
