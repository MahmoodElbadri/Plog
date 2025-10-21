import {Injectable} from '@angular/core';
import {AddBlogPostModel} from "../models/add-blog-post-model";
import {Observable} from "rxjs";
import {BlogPost} from "../models/Blog-Post-Model";
import {HttpClient} from "@angular/common/http";
import {environment} from "../../../../../environments/environment";
import {UpdateBlogPostModel} from "../models/update-blog-post-model";

@Injectable({
  providedIn: 'root'
})
export class BlogPostService {
  constructor(private http: HttpClient) {

  }

  addBlogPost(model: AddBlogPostModel): Observable<BlogPost> {
    return this.http.post<BlogPost>(`${environment.apiUrl}/BlogPosts`, model);
  }

  getBlogPosts():Observable<BlogPost[]>{
    return this.http.get<BlogPost[]>(`${environment.apiUrl}/blogposts`);
  }

  getBlogPostByID(id: string):Observable<BlogPost>{
    return this.http.get<BlogPost>(`${environment.apiUrl}/blogposts/${id}`);
  }

  updateBlogPost(id: string, updateBlogPost: UpdateBlogPostModel):Observable<BlogPost>{
    return this.http.put<BlogPost>(`${environment.apiUrl}/blogposts/${id}`, updateBlogPost);
  }

  deleteBlogPost(id:string):Observable<void>{
    return this.http.delete<void>(`${environment.apiUrl}/blogposts/${id}`);
  }

  getBlogPostByUrlHandle(urlHandle:string):Observable<BlogPost>{
    return this.http.get<BlogPost>(`${environment.apiUrl}/blogposts/${urlHandle}`);
  }
}
