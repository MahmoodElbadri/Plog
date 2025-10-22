import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {CategoryListComponent} from "./features/category/category-list/category-list.component";
import {AddCategoryComponent} from './features/category/add-category/add-category.component';
import {EditCategoryComponent} from "./features/category/edit-category/edit-category.component";
import {BlogPostListComponent} from "./features/blog-post/blog-post-list/blog-post-list.component";
import {AddBlogPostComponent} from "./features/blog-post/add-blog-post/add-blog-post.component";
import {EditBlogpostComponent} from "./features/blog-post/edit-blogpost/edit-blogpost.component";
import { HomeComponent } from './features/public/home/home.component';
import { BlogDetailsComponent } from './features/public/blog-details/blog-details.component';
import { LoginComponent } from './features/auth/login/login.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'blog/:urlHandle',
    component: BlogDetailsComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'admin/categories',
    component: CategoryListComponent
  },
  {
    path: 'admin/categories/add',
    component: AddCategoryComponent
  },
  {
    path: 'admin/categories/:id'
    , component: EditCategoryComponent
  },
  {
    path: 'admin/blog-posts',
    component: BlogPostListComponent
  },
  {
    path: 'admin/blog-posts/add',
    component: AddBlogPostComponent
  },
  {
    path: 'admin/blog-posts/:id',
    component: EditBlogpostComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
