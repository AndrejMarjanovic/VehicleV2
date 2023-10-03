import React, { useEffect } from 'react'
import { observer, inject } from "mobx-react";
import VehicleNavbar from "../components/VehicleNavbar"

const Homepage = ({ rootStore }) => {
  useEffect(() => {
    getData();
  }, [])

  const getData = () => {
    rootStore.vehicleStore.getVehiclesAsync();
  };

  return (
    <div>
      <VehicleNavbar />
      <div className="vehicleContainer">
        <div className="vehicleCardContainer">
          {rootStore.vehicleStore.vehicles.map((x) => (
            <div key={x.id} className="vehicleCard">
              <div className="vehicleCardContent">
                <href className="vehicleTitle">
                  {x.vehicleModel.vehicleMake.name} {x.vehicleModel.name}, {x.vehicleType.name}
                </href>
                <href className="vehicleLabel">{x.engine.horsepower} Hp, {x.engine.cubage}</href>
                <href className="vehicleLabel">Year: {x.productionYear}</href>
                <href className="vehicleLabel">Price: {x.price} KM</href>
              </div>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
}

export default inject("rootStore")(observer(Homepage));