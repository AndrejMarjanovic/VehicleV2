import React, { useState } from 'react'
import PhoneInput from 'react-phone-number-input'
import 'react-phone-number-input/style.css'
import { useNavigate } from 'react-router-dom';
import { observer, inject } from "mobx-react";

const Register = ({ rootStore }) => {
  const navigate = useNavigate();

  const [email, setEmail] = useState('');
  const [pass, setPass] = useState('');
  const [confirm, setConfirm] = useState('');
  const [name, setName] = useState('');
  const [lastname, setLastname] = useState('');
  const [username, setUsername] = useState('');
  const [phone, setPhone] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();

    let user = { name: name, lastname: lastname, username: username, email: email, phone: phone, password: pass, passwordconfirm: confirm };

    try {
      const response = await rootStore.userStore.registerUserAsync(user);
      if (response.status === 201) {
        window.alert("You created your account!");
        await rootStore.userStore.loginAsync(username, pass);
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
      window.alert("An error occurred while creating the account.");
    }
  }

  const handleRegisterClick = () => {
    navigate('/');
  }

  return (
    <div className="auth-form-container">
      <h2 className="Register-header">Register</h2>
      <form className="login-form" onSubmit={handleSubmit}>
        <label htmlFor="name">Name:</label>
        <input value={name} onChange={(e) => setName(e.target.value)} type="name" placeholder="Name" id="name" name="name" required/>
        <label htmlFor="lastname">Last name:</label>
        <input value={lastname} onChange={(e) => setLastname(e.target.value)} type="lastname" placeholder="Last name" id="lastname" name="lastname" required />
        <label htmlFor="username">Username:</label>
        <input value={username} onChange={(e) => { setUsername(e.target.value); e.target.setCustomValidity(''); }} autoComplete="off" type="username" placeholder="Username" id="username" name="username" required />
        <label htmlFor="email">E-mail:</label>
        <input value={email} onChange={(e) => { setEmail(e.target.value); e.target.setCustomValidity(''); }} type="email" placeholder="your_email@example.com" id="email" name="email" required />
        <label htmlFor="phone">Phone:</label>
        <PhoneInput value={phone} onChange={(e) => { setPhone(e); document.getElementById('phone').setCustomValidity(''); }} type="phone" placeholder="Enter phone number" id="phone" name="phone" required/>
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
        <button className="login-btn" type="submit">Register</button>
      </form>
      <button className="link-btn" onClick={handleRegisterClick}>Already have an account? Log In.</button>
    </ div>
  )
}

export default inject("rootStore")(observer(Register));