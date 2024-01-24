import { Generic } from './Generic'
import axios from '../Helpers/AxiosInstance'

export class JoinCategory extends Generic {
  protected routeName: string = "CategoryAction";

  public join = async (payload: any) => {
    return await axios.post(`${this.routeName}/join`,payload)
      .then((response) => response.data)
      .catch((error) => {
        if (error.response.status == 404) {
          console.log(error.response.data.message);
        }
        console.error(error.response);
        return {};
      });
  }

  public unjoin = async (payload: any) => {
    return await axios({
      method: 'delete',
      url: `${this.routeName}/unfollow`,
      data: payload
    })
      .then((response) => response.data)
      .catch((error) => {
        if (error.response.status == 400) {
          console.log(error.response.data.message);
        }
        console.error(error.response);
        return {};
      })
  }
}