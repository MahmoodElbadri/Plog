import { Injectable } from '@angular/core';
import { AddBlogPostModel } from "../models/add-blog-post-model";
import { Observable } from "rxjs";
import { BlogPost } from "../models/Blog-Post-Model";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../../../../environments/environment";
import { UpdateBlogPostModel } from "../models/update-blog-post-model";

@Injectable({
  providedIn: 'root'
})
export class BlogPostService {
  constructor(private http: HttpClient) {

  }


  getBlogPosts(): Observable<BlogPost[]> {
    return this.http.get<BlogPost[]>(`${environment.apiUrl}/blogposts`);
  }

  getBlogPostByID(id: string): Observable<BlogPost> {
    return this.http.get<BlogPost>(`${environment.apiUrl}/blogposts/${id}`);
  }

  addBlogPost(model: AddBlogPostModel): Observable<BlogPost> {
    return this.http.post<BlogPost>(`${environment.apiUrl}/BlogPosts?AddAuth=true`, model);
  }

  updateBlogPost(id: string, updateBlogPost: UpdateBlogPostModel): Observable<BlogPost> {
    return this.http.put<BlogPost>(`${environment.apiUrl}/blogposts/${id}?AddAuth=true`, updateBlogPost);
  }

  deleteBlogPost(id: string): Observable<void> {
    return this.http.delete<void>(`${environment.apiUrl}/blogposts/${id}?AddAuth=true`);
  }

  getBlogPostByUrlHandle(urlHandle: string): Observable<BlogPost> {
    return this.http.get<BlogPost>(`${environment.apiUrl}/blogposts/${urlHandle}`);
  }
}
