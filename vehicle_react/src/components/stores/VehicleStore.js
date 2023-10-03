import { makeObservable, observable } from "mobx";

class VehicleStore {
  constructor(apiService) {
    this.apiService = apiService;
    this.endpoint = "Vehicle";

    makeObservable(this, {
      vehicles: observable,
      vehicles: observable,
      sortBy: observable,
      isDesc: observable,
      search: observable,
      page: observable
    });
  }
  vehicle = {};
  vehicles = [];
  search = "";
  sortBy = "";
  isDesc = false;
  page = 1;


  getFilteredVehiclesAsync = async () => {
    const params = {
      sortBy: this.sortBy,
      isDesc: this.isDesc,
      search: this.search,
      page: this.page,
    };
    try {
      const { data } = await this.apiService.getFiltered(this.endpoint, params);
      this.vehicles = [...data];
    } catch (error) {
      console.log(error);
    }
  };

  getVehiclesAsync = async () => {
    try {
      const { data } = await this.apiService.get(this.endpoint);
      this.vehicles = [...data];
    } catch (error) {
      console.log(error);
    }
  };

  getVehicleById = async (Id) => {
    try {
      const { data } = await this.apiService.getById(this.endpoint, Id);
      this.vehicle = { ...data };
    } catch (error) {
      console.log(error);
    }
  };

  postVehicleAsync = async (vehicle) => {
    try {
      const response = await this.apiService.post(this.endpoint, vehicle);
      if (response.status === 201) {
        console.log(response);
      }
    } catch (error) {
      console.log(error);
    }
  };

  putVehicleAsync = async (id, vehicle) => {
    try {
      const response = await this.apiService.put(this.endpoint, id, vehicle);
      if (response.status === 200) {
        console.log(response);
      }
    } catch (error) {
      console.log(error);
    }
  };

  deleteVehicleAsync = async (id) => {
    try {
      await this.apiService.delete(this.endpoint, id);
    } catch (error) {
      console.log(error);
    }
  };

  sortVehicleBy = async (radio, check) => {
    this.sortBy = radio;
    this.isDesc = check;
    await this.getFilteredVehiclesAsync();
  };

  searchVehicles = async (search) => {
    this.search = search;
    await this.getFilteredVehiclesAsync();
  };

  setVehicleAtributes = async (e) => {
    this.vehicle = { ...this.vehicle, [e.target.name]: e.target.value };
  }

  setPageNumber = async (x) => {
    this.page = x;
    await this.getFilteredVehiclesAsync();
  };
}

export { VehicleStore };