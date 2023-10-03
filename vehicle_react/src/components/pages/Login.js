import React, { useState } from 'react'
import { observer, inject } from "mobx-react";
import { useNavigate } from 'react-router-dom';

const Login = ({ rootStore }) => {
  const navigate = useNavigate();

  const [username, setUsername] = useState('');
  const [pass, setPass] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      if (await rootStore.userStore.loginAsync(username, pass)) {
        navigate('/homepage'); 
      }
    } catch (error) {
      if (error.response.status === 401) {
        window.alert("Invalid user credentials.");
      }
      else {
        window.alert("Login failed.");
      }
      setUsername("");
      setPass("");
    }
  }

  const handleRegisterClick = () => {
    navigate('/register'); 
  }

  return (
    <div className="auth-form-container">
      <h2 className="Login-header"> Login</h2>
      <form className="login-form" onSubmit={handleSubmit}>
        <label htmlFor="username">Username:</label>
        <input value={username} onChange={(e) => setUsername(e.target.value)} type="username" required placeholder="Enter username" id="username" name="username" />
        <label htmlFor="password">Password:</label>
        <input value={pass} onChange={(e) => setPass(e.target.value)} type="password" required placeholder="*******" id="password" name="password" />
        <button className="login-btn"  type="submit">Log In</button>
      </form>
      <button className="link-btn" onClick={handleRegisterClick}>Don't have an account? Register.</button>
    </div>
  )
}

export default inject("rootStore")(observer(Login));