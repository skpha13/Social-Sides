import { Generic } from '@/models/Generic'
import axios from '@/Helpers/AxiosInstance'

export class Like extends Generic {
  protected routeName: string = 'PostAction'

  public like = async (postId: string) => {
    return await axios.post(`${this.routeName}/like/${postId}`)
      .then((response) => response.data)
      .catch((error) => {
        console.error(error.response);
        throw error.response.data.title;
      })
  }
}