import { Component } from '@angular/core';
import { AddBlogPostModel } from "../models/add-blog-post-model";
import { BlogPostService } from "../services/blog-post.service";
import { Router } from "@angular/router";

@Component({
  selector: 'app-add-blog-post',
  templateUrl: './add-blog-post.component.html',
  styleUrls: ['./add-blog-post.component.css']
})
export class AddBlogPostComponent {
  model: AddBlogPostModel;

  constructor(
    private blogPostService: BlogPostService,
    private router: Router
  ) {
    this.model = {
      title: '',
      shortDescription: '',
      featuredImageUrl: '',
      content: '',
      author: '',
      urlHandle: '',
      publishedDate: new Date().toISOString(),
      isVisible: true
    };
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
}
