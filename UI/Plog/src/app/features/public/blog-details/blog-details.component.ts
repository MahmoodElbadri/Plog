import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { BlogPostService } from '../../blog-post/services/blog-post.service';
import { BlogPost } from '../../blog-post/models/Blog-Post-Model';

@Component({
  selector: 'app-blog-details',
  templateUrl: './blog-details.component.html',
  styleUrls: ['./blog-details.component.css']
})
export class BlogDetailsComponent implements OnInit {

  urlHandle: string | null = null;
  getBlogPostByUrlHandleSubscription?: Subscription;
  post: BlogPost | null = null;
  /**
   *
   */
  constructor(private router: ActivatedRoute,
              private blogPostService: BlogPostService
  ) {

  }
  ngOnInit(): void {
    this.router.paramMap.subscribe(params => {
     this.urlHandle = params.get('urlHandle');
     if(this.urlHandle){
       this.getBlogPostByUrlHandleSubscription = this.blogPostService.getBlogPostByUrlHandle(this.urlHandle).subscribe({
         next: (response) => {
           console.log(response);
           this.post = response;
         },
         error: (error) => {
           console.log(error);
         },
         complete: () => {
           console.log("Blog post retrieved successfully");
         }
       })
     }
    })
  }

}
