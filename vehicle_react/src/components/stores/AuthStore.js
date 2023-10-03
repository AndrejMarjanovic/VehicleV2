import { makeObservable, observable, action } from "mobx";

class AuthStore {
  constructor() {
    makeObservable(this, {
      username: observable,
      password: observable,
      setUsernameAndPassword: action,
      clearAuthData: action,
      getAuthConfig: action,
    });
  }

  username = "";
  password = "";

  setUsernameAndPassword(username, password) {
    this.username = username;
    this.password = password;
  }

  updatePassword(password) {
    this.password = password;
  }

  updateUsername(username) {
    this.username = username;
  }

  clearAuthData() {
    this.username = "";
    this.password = "";
  }

  getAuthConfig() {
    return {
      auth: {
        username: this.username,
        password: this.password
      }
    };
  }

  getUsername() {
    return this.username
  };

  getPassword() {
    return this.password
  };

}

export { AuthStore };