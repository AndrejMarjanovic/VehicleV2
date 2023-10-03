import { VehicleMakeStore } from "./VehicleMakeStore";
import { VehicleModelStore } from "./VehicleModelStore";
import { VehicleStore } from "./VehicleStore"
import { UserStore } from "./UserStore";
import { APIService } from "../services/APIService";
import { AuthStore } from "./AuthStore";

export class RootStore {
  constructor() {
   this.authStore = new AuthStore();
   const apiService = new APIService("https://localhost:7055/api", this.authStore);
   this.vehicleStore = new VehicleStore(apiService);
   this.vehicleMakeStore = new VehicleMakeStore(apiService);
   this.vehicleModelStore = new VehicleModelStore(apiService);
   this.userStore = new UserStore(apiService);
  }
}
