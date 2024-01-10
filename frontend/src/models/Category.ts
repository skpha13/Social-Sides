import { Generic } from './Generic'

export class Category extends Generic {
  protected routeName: string = "Category";
}

export interface ICategory {
    id: string,
    title: string,
    color: string
}