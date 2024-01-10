import axios from '../Helpers/AxiosInstance'

export abstract class Generic {
  protected routeName: string = '';

  public all = async (params: string = '') => {
    return await axios.get(`${this.routeName}/all${params}`)
      .then((response) => response.data)
      .catch((error) => {
        if (error.response.status == 404) {
          // TODO: router.push({name: 'notfound'});
          console.log(error.response.data.message);
        }
        console.error(error.response);
        return [];
      });
  }
}