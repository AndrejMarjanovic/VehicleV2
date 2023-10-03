import './App.css';
import { observer, inject } from "mobx-react";
import React, { useState, useEffect } from 'react';
import AppRoutes from './Routes';
import ChatButton from './components/components/ChatButton';
import ChatComponent from './components/components/ChatComponent';

function App({ rootStore }) {
  const [isChatVisible, setIsChatVisible] = useState(false);
  const user = rootStore.authStore.getUsername();

  const toggleChatVisibility = () => {
    setIsChatVisible(!isChatVisible);
  };

  return (
    <div className='App'>
      <AppRoutes />
      {user !== "" && !isChatVisible && <ChatButton onClick={toggleChatVisibility} />}
      {user !== "" && <ChatComponent isChatVisible={isChatVisible} closeChat={toggleChatVisibility} user={user}/>}
    </ div>

  );
}

export default inject("rootStore")(observer(App));
