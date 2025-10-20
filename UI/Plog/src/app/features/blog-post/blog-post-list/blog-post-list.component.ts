import {Component, OnDestroy, OnInit} from '@angular/core';
import {BlogPostService} from "../services/blog-post.service";
import {BlogPost} from "../models/Blog-Post-Model";
import {Observable, Subscription} from "rxjs";

@Component({
  selector: 'app-blog-post-list',
  templateUrl: './blog-post-list.component.html',
  styleUrls: ['./blog-post-list.component.css']
})
export class BlogPostListComponent implements OnInit, OnDestroy {

  // blogPost$?: Observable<BlogPost[]>;
  //another approach
  blogPosts?: BlogPost[];
  blogPostSubscription?: Subscription;

  constructor(private blogPostService: BlogPostService) {

  }


  ngOnInit(): void {
    // this.blogPost$ = this.blogPostService.getBlogPosts();
    this.blogPostSubscription = this.blogPostService.getBlogPosts().subscribe({
      next: (response) => {
        console.log(response);
        // console.log("Categories are", response.categories);
        this.blogPosts = response;
      },
      error: (err) => {
        console.log(err);
      },
      complete: () => {
        console.log("Completed");
      }
    })
  }

  //also included in the second approach
  ngOnDestroy(): void {
    this.blogPostSubscription?.unsubscribe();
  }

}
