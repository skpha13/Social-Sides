import { Generic } from './Generic'
import type { ICategory } from './Category'
import type { IUser } from './User'

export class Post extends Generic {
  protected routeName: string = "Post";
}

export interface IPost {
  id: string,
  dateCreated: string,
  text: string,
  relations: {
    category: ICategory,
    user: IUser
  }
}