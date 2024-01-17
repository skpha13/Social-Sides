import { Generic } from '@/models/Generic'
import axios from '@/Helpers/AxiosInstance'

export class Comment extends Generic {
  protected routeName: string = 'PostAction'

  public comment = async (payload: any) => {
    return await axios.post(`${this.routeName}/comment`, payload)
      .then((response) => response.data)
      .catch((error) => {
        console.error(error.response);
        throw error.response.data.title;
      })
  }

  public deleteComment = async (commentId: string) => {
    return await axios.delete(`${this.routeName}/delete-comment/${commentId}`)
      .then((response) => response.data)
      .catch((error) => {
        console.error(error.response);
        throw error.response.data.title;
      })
  }
}

export interface IComment {
  id: string,
  text: string,
  userId: string,
  userName: string,
  lastModified: string
}