import React, { useRef, useState, useEffect } from 'react';
import { observer, inject } from "mobx-react";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTimes, faPaperPlane, faExpand } from '@fortawesome/free-solid-svg-icons';
import { HubConnectionBuilder } from '@microsoft/signalr';

const ChatComponent = ({ isChatVisible, closeChat, user }) => {
  const [isMaximized, setIsMaximized] = useState(false);
  const [message, setMessage] = useState('');
  const [messages, setMessages] = useState([]);
  const [hubConnection, setHubConnection] = useState(null);

  const chatContainerRef = useRef(null);

  useEffect(() => {

    const connection = new HubConnectionBuilder().withUrl('https://localhost:7055/ChatHub').build();
    setHubConnection(connection);

    connection
      .start()
      .then(() => console.log('Connection started!'))
      .catch(console.log('Error while establishing connection.'));

    connection.on("ReceiveMessage", (receivedUser, receivedMessage) => {

      setMessages(prevMessages => [
        ...prevMessages,
        { user: receivedUser, message: receivedMessage },
      ]);
    });

    return () => {
      if (connection) { 
        connection
          .invoke('UserLoggedOut', user)
          .catch((error) => {
            console.error('Error invoking UserLoggedOut:', error);
          });
      }
      connection.stop();
    };
    
  }, []);

  useEffect(() => {
    if (hubConnection && isChatVisible) { 
      hubConnection
        .invoke('UserLoggedIn', user)
        .catch((error) => {
          console.error('Error invoking UserLoggedIn:', error);
        });
    }
  }, [hubConnection, isChatVisible, user]);

  useEffect(() => {
    chatContainerRef.current.scrollTop = chatContainerRef.current.scrollHeight;
  }, [messages]);

  const sendMessage = () => {
    if (message.trim() !== '') {
      hubConnection
        .invoke('SendMessage', user, message)
        .catch(err => console.error(err));

      setMessage('');
    }
  };

  const onMaximizeClick = () => {
    setIsMaximized(!isMaximized);
  }

  const handleMessageChange = (e) => {
    setMessage(e.target.value);
  };

  const handleInputKeyPress = (e) => {
    if (e.key === 'Enter') {
      sendMessage();
    }
  };

  const onCloseClick = () => {
    if (hubConnection) { 
      hubConnection
        .invoke('UserLoggedOut', user)
        .catch((error) => {
          console.error('Error invoking UserLoggedOut:', error);
        });
    }

    closeChat();
  }

  function formatDate(dateString) {
    const options = {
      year: 'numeric',
      month: 'short',
      day: '2-digit',
      hour: '2-digit',
      minute: '2-digit',
    };
  
    const formattedDate = new Date(dateString).toLocaleString('en-US', options);
    return formattedDate;
  }

  return (
    <div className={`chat-component ${isChatVisible ? 'visible' : ''} ${isMaximized ? 'maximized' : ''}`}>
      <div className="chat-header">
        <href className="minimize-button" onClick={onMaximizeClick}>
          <FontAwesomeIcon icon={faExpand} />
        </href>
        <href> Chat </href>
        <href className="close-button" onClick={onCloseClick}>
          <FontAwesomeIcon icon={faTimes} />
        </href>
      </div>
      <div className="chat-content" ref={chatContainerRef}>
        {messages.map((message, index) => (
          <div key={index} className={`chat-message ${message.user !== user ? 'received' : 'sent'}`}>
            <div className="message-sender">{message.user}, {formatDate(Date())} </div>
            <div className="message-content">{message.message}</div>
          </div>
        ))}
      </div>
      <div className="chat-input">
        <input
          type="text"
          placeholder="Type your message..."
          value={message}
          onChange={handleMessageChange}
          onKeyDown={handleInputKeyPress}
        />
        <href className="send-button" onClick={sendMessage}>
          <FontAwesomeIcon icon={faPaperPlane} />
        </href>
      </div>
    </div>
  );
};

export default inject("rootStore")(observer(ChatComponent));