import {Component} from '@angular/core';
import {AddBlogPostModel} from "../models/add-blog-post-model";

@Component({
  selector: 'app-add-blog-post',
  templateUrl: './add-blog-post.component.html',
  styleUrls: ['./add-blog-post.component.css']
})
export class AddBlogPostComponent {
  model: AddBlogPostModel;

  constructor() {
    this.model = {
      title: '',
      shortDescription: '',
      featureImageUrl: '',
      content: '',
      author: '',
      urlHandle: '',
      publishedDate: new Date().toDateString(),
      isVisible: true
    }


  }

  onFormSubmit() {
    console.log(this.model);
  }
}
