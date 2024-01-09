import { Generic } from './Generic'

export class Category extends Generic {
  protected routeName: string = "Category";
}

export interface ICategory {
  categories: [
    {
      id: string,
      title: string,
      color: string
    }
  ]
}