import { makeObservable, observable } from "mobx";

class VehicleMakeStore {
  constructor(apiService) {
    this.apiService = apiService;
    this.endpoint = "VehicleMake";

    makeObservable(this, {
      makes: observable,
      make: observable,
      sortBy: observable,
      isDesc: observable,
      search: observable,
      page: observable
    });
  }
  make = {};
  makes = [];
  search = "";
  sortBy = "";
  isDesc = false;
  page = 1;


  getFilteredVehicleMakesAsync = async () => {
    const params = {
      sortBy: this.sortBy,
      isDesc: this.isDesc,
      search: this.search,
      page: this.page,
    };
    try {
      const { data } = await this.apiService.getFiltered(this.endpoint, params);
      this.makes = [...data];
    } catch (error) {
      console.log(error);
    }
  };

  getVehicleMakesAsync = async () => {
    try {
      const { data } = await this.apiService.get(this.endpoint);
      this.makes = [...data];
    } catch (error) {
      console.log(error);
    }
  };

  getVehicleMakeById = async (Id) => {
    try {
      const { data } = await this.apiService.getById(this.endpoint, Id);
      this.make = { ...data };
    } catch (error) {
      console.log(error);
    }
  };

  postVehicleMakeAsync = async (make) => {
    try {
      const response = await this.apiService.post(this.endpoint, make);
      if (response.status === 201) {
        console.log(response);
      }
    } catch (error) {
      console.log(error);
    }
  };

  putVehicleMakeAsync = async (id, make) => {
    try {
      const response = await this.apiService.put(this.endpoint, id, make);
      if (response.status === 200) {
        console.log(response);
      }
    } catch (error) {
      console.log(error);
    }
  };

  deleteVehicleMakeAsync = async (id) => {
    try {
      await this.apiService.delete(this.endpoint, id);
    } catch (error) {
      console.log(error);
    }
  };

  sortVehicleMakesBy = async (radio, check) => {
    this.sortBy = radio;
    this.isDesc = check;
    await this.getFilteredVehicleMakesAsync();
  };

  searchVehicleMakes = async (search) => {
    this.search = search;
    await this.getFilteredVehicleMakesAsync();
  };

  setMakeAtributes = async (e) => {
    this.make = { ...this.make, [e.target.name]: e.target.value };
  }

  setPageNumber = async (x) => {
    this.page = x;
    await this.getFilteredVehicleMakesAsync();
  };
}

export { VehicleMakeStore };