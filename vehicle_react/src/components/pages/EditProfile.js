import React from 'react'
import PhoneInput from 'react-phone-number-input'
import 'react-phone-number-input/style.css'
import { useNavigate } from 'react-router-dom';
import VehicleNavbar from "../components/VehicleNavbar"
import { observer, inject } from "mobx-react";

const EditProfile = ({ rootStore }) => {

  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const user = rootStore.userStore.user;
      const response = await rootStore.userStore.updateUserAsync(user.id, user);
      if (response.status === 200) {
        window.alert("You successfully updated your account!");
        await rootStore.authStore.updateUsername(user.username);
        navigate('../homepage');
      } else if (response.status === 400) {
        const errorData = response.data;

        if (errorData === "User with the same username already exists.") {
          document.getElementById('username').setCustomValidity(errorData);
        }
        else if (errorData === "User with the same E-mail already exists.") {
          document.getElementById('email').setCustomValidity(errorData);
        }
        else if (errorData === "User with the same phone number already exists.") {
          document.getElementById('phone').setCustomValidity(errorData);
        }

        e.target.reportValidity();
      }
    } catch (error) {
      window.alert("An error occurred while updating the account.");
      navigate('../homepage');
    }
  }

  const user = rootStore.userStore.user;

  return (
    <div>
      <VehicleNavbar />
      <div className="auth-form-container">
        <h2 className="Register-header">Update account</h2>
        <form className="login-form" onSubmit={handleSubmit}>
          <label htmlFor="name">Name:</label>
          <input
            value={user?.name || ''}
            onChange={(e) => rootStore.userStore.setUserAtributes(e)}
            type="text"
            placeholder={user?.name || ''}
            id="name"
            name="name"
            required
          />
          <label htmlFor="lastname">Last name:</label>
          <input
            value={user?.lastname || ''}
            onChange={(e) => rootStore.userStore.setUserAtributes(e)}
            type="text"
            placeholder={user?.lastname || ''}
            id="lastname"
            name="lastname"
            required
          />
          <label htmlFor="username">Username:</label>
          <input
            value={user?.username || ''}
            onChange={(e) => {
              rootStore.userStore.setUserAtributes(e);
              e.target.setCustomValidity('');
            }}
            autoComplete="off"
            type="text"
            placeholder={user?.username || ''}
            id="username"
            name="username"
            required
          />
          <label htmlFor="email">E-mail:</label>
          <input
            value={user?.email || ''}
            onChange={(e) => {
              rootStore.userStore.setUserAtributes(e);
              e.target.setCustomValidity('');
            }}
            type="email"
            placeholder={user?.email || ''}
            id="email"
            name="email"
            required
          />
          <label htmlFor="phone">Phone:</label>
          <PhoneInput
            value={user?.phone || ''}
            onChange={(e) => {
              rootStore.userStore.setUserAtributes(e);
              document.getElementById('phone').setCustomValidity('');
            }}
            placeholder={user?.phone || ''}
            id="phone"
            name="phone"
            required
          />

          <button className="login-btn" type="submit">
            Update
          </button>
        </form>
      </div>
    </div>
  );
}

export default inject("rootStore")(observer(EditProfile));