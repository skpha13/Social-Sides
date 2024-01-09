import axios from '../Helpers/AxiosInstance'
import { useRoute, useRouter } from 'vue-router'

export abstract class Generic {
  protected routeName: string = '';

  public all = async () => {
    return await axios.get(`${this.routeName}/all`)
      .then((response) => response.data)
      .catch((error) => {
        if (error.response.status == 404) {
          // TODO: router.push({name: 'notfound'});
          console.log(error);
        }
        console.error(error.response);
        return [];
      });
  }
}