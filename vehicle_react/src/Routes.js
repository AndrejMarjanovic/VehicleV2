import React from 'react';
import './App.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Login from './components/pages/Login';
import Homepage from './components/pages/Homepage';
import Register from './components/pages/Register';
import VehicleMake from './components/pages/VehicleMake';
import VehicleModel from './components/pages/VehicleModel';
import EditProfile from './components/pages/EditProfile';
import UpdatePassword from './components/pages/UpdatePassword';

const AppRoutes = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="/homepage" element={<Homepage />} />
        <Route path="/vehicleMake" element={<VehicleMake />} />
        <Route path="/vehicleModel" element={<VehicleModel />} />
        <Route path="/account" element={<EditProfile />} />
        <Route path="/update-password" element={<UpdatePassword />} />
      </Routes>
    </BrowserRouter>
  );
};

export default AppRoutes;