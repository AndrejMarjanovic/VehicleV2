import { makeObservable, observable, action } from "mobx";

class UserStore {
  constructor(apiService) {
    this.apiService = apiService;
    this.endpoint = "User";

    makeObservable(this, {
      users: observable,
      user: observable,
      sortBy: observable,
      isDesc: observable,
      search: observable,
      page: observable,
      setUserAtributes: action
    });
  }

  user = {};
  users = [];
  search = "";
  sortBy = "";
  isDesc = false;
  page = 1;


  loginAsync = async (username, password) => {
    try {

      this.apiService.setUsernameAndPassword(username, password);
      const response = await this.apiService.getFiltered(this.endpoint, { search: username });

      if (response.data.length > 0) {
        this.user = response.data[0];
        return true;
      } else {
        return false;
      }
    } catch (error) {
      this.apiService.clearUsernameAndPassword();
      console.log(error);
      throw error;
    }
  };


  registerUserAsync = async (user) => {
    try {
      const response = await this.apiService.register(this.endpoint, user);
      console.log(response);
      return response;
    } catch (error) {
      console.log(error);
      return error;
    }
  };

  getFilteredUsersAsync = async () => {
    const params = {
      sortBy: this.sortBy,
      isDesc: this.isDesc,
      search: this.search,
      page: this.page,
    };
    try {
      const { data } = await this.apiService.getFiltered(this.endpoint, params);
      this.users = [...data];
    } catch (error) {
      console.log(error);
    }
  };

  getUsersAsync = async () => {
    try {
      const { data } = await this.apiService.get(this.endpoint);
      this.users = [...data];
      return [...data];
    } catch (error) {
      console.log(error);
      return [];
    }
  };

  getUserById = async (Id) => {
    try {
      const { data } = await this.apiService.getById(this.endpoint, Id);
      this.user = { ...data };
    } catch (error) {
      console.log(error);
    }
  };

  updateUserAsync = async (id, user) => {
    try {
      const response = await this.apiService.put(this.endpoint + "/EditUser", id, user);
      console.log(response);
      return response;
    } catch (error) {
      console.log(error);
      return error;
    }
  };

  setUserAtributes = async (e) => {
    if (typeof e === 'string' || e === null) {
      this.user.phone = e;
    } else {
      this.user = { ...this.user, [e.target.name]: e.target.value };
    }
  }

}

export { UserStore };