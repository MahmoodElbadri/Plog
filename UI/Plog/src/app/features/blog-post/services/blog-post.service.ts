import {Injectable} from '@angular/core';
import {AddBlogPostModel} from "../models/add-blog-post-model";
import {Observable} from "rxjs";
import {BlogPost} from "../models/Blog-Post-Model";
import {HttpClient} from "@angular/common/http";
import {environment} from "../../../../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class BlogPostService {
  constructor(private http: HttpClient) {

  }

  addBlogPost(model: AddBlogPostModel): Observable<BlogPost> {
    return this.http.post<BlogPost>(`${environment.apiUrl}/BlogPosts`, model);
  }
}
