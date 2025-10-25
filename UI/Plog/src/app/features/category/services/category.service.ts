import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../../environments/environment";
import { AddCategoryRequest } from "../models/add-category-request-model";
import { category } from "../models/category.model";
import { UpdateCategoryRequest } from "../models/update-category-request";
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient,
    private cookieSer: CookieService
  ) {

  }


  getCategories(): Observable<category[]> {
    return this.http.get<category[]>(`${environment.apiUrl}/categories`);
  }

  getCategoryByID(id: string): Observable<category> {
    return this.http.get<category>(`${environment.apiUrl}/categories/${id}`);
  }

  addCategory(model: AddCategoryRequest): Observable<void> {
    return this.http.post<void>(`${environment.apiUrl}/categories?AddAuth=true`, model);
  }

  updateCategory(id: string, updateCategoryRequest: UpdateCategoryRequest): Observable<category> {
    return this.http.put<category>(`${environment.apiUrl}/categories/${id}?AddAuth=true`, updateCategoryRequest);
  }

  deleteCategory(id: string): Observable<void> {
    return this.http.delete<void>(`${environment.apiUrl}/categories/${id}?AddAuth=true`);
  }
}
