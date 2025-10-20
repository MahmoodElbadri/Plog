import {category} from "../../category/models/category.model";

export interface BlogPost{
  id: string;
  title: string;
  shortDescription: string;
  featureImageUrl: string;
  content: string;
  author: string;
  urlHandle: string;
  publishedDate: string | Date;
  isVisible: boolean;
  categories: category[];
}
