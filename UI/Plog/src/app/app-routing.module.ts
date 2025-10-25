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
import { authGuard } from './features/auth/guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    title: 'Home - Blog'
  },
  {
    path: 'blog/:urlHandle',
    component: BlogDetailsComponent,
    title: 'Blog Details - Blog'
  },
  {
    path: 'login',
    component: LoginComponent,
    title: 'Login - Blog'
  },
  {
    path: 'admin/categories',
    component: CategoryListComponent,
    canActivate: [authGuard],
    title: 'Categories - Blog'
  },
  {
    path: 'admin/categories/add',
    component: AddCategoryComponent,
    canActivate: [authGuard],
    title: 'Add Category - Blog'
  },
  {
    path: 'admin/categories/:id'
    , component: EditCategoryComponent,
    canActivate: [authGuard],
    title: 'Edit Category - Blog'
  },
  {
    path: 'admin/blog-posts',
    component: BlogPostListComponent,
    canActivate: [authGuard],
    title: 'Blog Posts - Blog'
  },
  {
    path: 'admin/blog-posts/add',
    component: AddBlogPostComponent,
    canActivate: [authGuard],
    title: 'Add Blog Post - Blog'
  },
  {
    path: 'admin/blog-posts/:id',
    component: EditBlogpostComponent,
    canActivate: [authGuard],
    title: 'Edit Blog Post - Blog'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
