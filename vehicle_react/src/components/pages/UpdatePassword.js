import React, { useState } from 'react'
import 'react-phone-number-input/style.css'
import { useNavigate } from 'react-router-dom';
import VehicleNavbar from "../components/VehicleNavbar"
import { observer, inject } from "mobx-react";

const UpdatePassword = ({ rootStore }) => {
  const navigate = useNavigate();

  const [pass, setPass] = useState('');
  const [confirm, setConfirm] = useState('');
  const [passOld, setOld] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();
    
    if (passOld !== rootStore.authStore.getPassword()) {
      e.target.elements['password-old'].setCustomValidity('Old password is incorrect');
      e.target.reportValidity();
      return;
    }

    try {
      const user = rootStore.userStore.user;
      const updatedPass = { ...user, password: pass, passwordconfirm: confirm };
      const response = await rootStore.userStore.updateUserAsync(user.id, updatedPass);
      if (response.status === 200) {
        window.alert("You successfully updated your password!");
        await rootStore.authStore.updatePassword(pass);
        navigate('../homepage');
      }
    } catch (error) {
      window.alert("An error occurred while updating your password.");
      navigate('../homepage');
    }
  }

  return (
    <div>
      <VehicleNavbar />
      <div className="auth-form-container">
        <h2 className="Register-header">Change password</h2>
        <form className="login-form" onSubmit={handleSubmit}>
          <label htmlFor="password">Old password:</label>
          <input value={passOld} onChange={(e) => { setOld(e.target.value); e.target.setCustomValidity(''); }} type="password" placeholder="*******" id="password-old" name="password-old" required />
          <label htmlFor="password">Password:</label>
          <input value={pass} onChange={(e) => setPass(e.target.value)} type="password" placeholder="*******" id="password" name="password" required />
          <label htmlFor="confirm-password">Confirm:</label>
          <input value={confirm} onChange={(e) => setConfirm(e.target.value)} type="password" placeholder="*******" id="confirm-password" name="confirm-password" required
            onInput={(e) => {
              if (e.target.value === pass) {
                e.target.setCustomValidity("");
              }
              else {
                e.target.setCustomValidity("Passwords don't match.");
              }
            }} />
          <button className="login-btn" type="submit">
            Update
          </button>
        </form>
      </div>
    </div>
  );
}

export default inject("rootStore")(observer(UpdatePassword));