import axios from "axios";

class APIService {
  constructor(baseUrl, authStore) {
    this.baseUrl = baseUrl;
    this.authStore = authStore;
  }

 /* saveAuthToStore() {
    this.authStore.saveToLocalStorage();
  }*/

  /*loadAuthFromStore() {
    this.authStore.loadFromLocalStorage();
  }*/

  setUsernameAndPassword(username, password) {
    this.authStore.setUsernameAndPassword(username, password);
  }

  clearUsernameAndPassword() {
    this.authStore.clearAuthData();
  }

  get = (endpoint) => {
    const url = `${this.baseUrl}/${endpoint}`;
    return axios.get(url, { ...this.authStore.getAuthConfig() } );
  };

  getFiltered = async (endpoint, filters) => {
    const url = `${this.baseUrl}/${endpoint}/Filtered`;
    try {
      const response = await axios.get(url, {
        params: { ...filters },
        ...this.authStore.getAuthConfig(), });
      return response;
    } catch (error) {
      throw error;
    }
  };

  getById = (endpoint, Id) => {
    const url = `${this.baseUrl}/${endpoint}/${Id}`;
    return axios.get(url, { ...this.authStore.getAuthConfig() });
  };


  post = async (endpoint, object) => {
    const url = `${this.baseUrl}/${endpoint}`;
    try {
      const response = await axios.post(url, object, { ...this.authStore.getAuthConfig() });
      return response;
    } catch (error) {
      console.log(error);
      throw error;
    }
  };


  register = async (endpoint, object) => {
    try {
      const url = `${this.baseUrl}/${endpoint}/Register`;
      const response = await axios.post(url, object);
      return response;
    } catch (error) {
      console.log(error);
      return error.response || error;
    }
  };

  put(endpoint, id, object) {
    try {
    const url = `${this.baseUrl}/${endpoint}/${id}`;
    return axios.put(url, object, { ...this.authStore.getAuthConfig()});
    } catch(error){
      console.log(error);
    }
  }

  delete = (endpoint, id) => {
    const url = `${this.baseUrl}/${endpoint}/${id}`;
    return axios.delete(url, { ...this.authStore.getAuthConfig()});
  };
}

export { APIService };