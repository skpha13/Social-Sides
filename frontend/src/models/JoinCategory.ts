import { Generic } from './Generic'
import axios from '../Helpers/AxiosInstance'

export class JoinCategory extends Generic {
  protected routeName: string = "CategoryAction";

  public join = async (payload: any) => {
    return await axios.post(`${this.routeName}/join`,payload)
      .then((response) => response.data)
      .catch((error) => {
        if (error.response.status == 404) {
          // TODO: router.push({name: 'notfound'});
          console.log(error.response.data.message);
        }
        console.error(error.response);
        return {};
      });
  }
}