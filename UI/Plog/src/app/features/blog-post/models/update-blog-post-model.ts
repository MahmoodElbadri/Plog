export interface UpdateBlogPostModel {
  title: string;
  shortDescription: string;
  featuredImageUrl: string;
  content: string;
  author: string;
  urlHandle: string;
  publishedDate: string | Date;
  isVisible: boolean;
  categories: string[];
}
