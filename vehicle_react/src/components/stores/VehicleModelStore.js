import { makeObservable, observable } from "mobx";


class VehicleModelStore {
  constructor(apiService) {
    this.apiService = apiService;
    this.endpoint = "VehicleModel";

    makeObservable(this, {
      model: observable,
      models: observable,
      search: observable,
      sortBy: observable,
      isDesc: observable,
      page: observable,
    });
  }
  model = {};
  models = [];
  search = "";
  sortBy = "";
  isDesc = false;
  page = 1;

  getVehicleModelsAsync = async () => {
    try {
      const { data } = await this.apiService.get(this.endpoint);
    this.models = [...data];
    } catch (error) {
      console.log(error);
    }
  };

  getFilteredVehicleModelsAsync = async () => {
    const params = {
      sortBy: this.sortBy,
      isDesc: this.isDesc,
      search: this.search,
      page: this.page
    };
    try {
      const { data } = await this.apiService.getFiltered(this.endpoint, params);
    this.models = [...data];
    } catch (error) {
      console.log(error);
    }
  };

  getVehicleModelById = async (Id) => {
    try {
      const { data } = await this.apiService.getById(this.endpoint, Id);
      this.model = { ...data };
    } catch (error) {
      console.log(error);
    }
  };

  postVehicleModelAsync = async (model) => {
    try {
      const response = await this.apiService.post(this.endpoint, model);
      if (response.status === 201) {
        console.log(response);
      }
    } catch (error) {
      console.log(error);
    }
  };

  putVehicleModelAsync = async (id, model) => {
    try {
      const response = await this.apiService.put(this.endpoint, id, model);
      if (response.status === 200) {
        console.log(response);
      }
    } catch (error) {
      console.log(error);
    }
  };

  deleteVehicleModelAsync = async (id) => {
    try {
      await this.apiService.delete(this.endpoint, id);
    } catch (error) {
      console.log(error);
    }
  };

  sortVehicleModelsBy = async (radio, check) => {
    this.sortBy = radio;
    this.isDesc = check;
    await this.getFilteredVehicleModelsAsync();
  };

  searchVehicleModels = async (search) => {
    this.search = search;
    await this.getFilteredVehicleModelsAsync();
  };

  setModelAtributes = async (e) => {
    this.model = { ...this.model, [e.target.name]: e.target.value };
  }

  setPageNumber = async (x) => {
    this.page = x;
    await this.getFilteredVehicleModelsAsync();
  };

}

export { VehicleModelStore };