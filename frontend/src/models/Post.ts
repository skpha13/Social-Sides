import { Generic } from './Generic'
import type { ICategory } from './Category'
import type { IUser } from './User'
import type { IComment } from './Comment'

export class Post extends Generic {
  protected routeName: string = "Post";
}

export interface IPost {
  id: string,
  dateCreated: string,
  text: string,
  totalLikes: number,
  isLikedByUser: boolean,
  relations: {
    category: ICategory,
    user: IUser,
    comments: IComment[]
  }
}