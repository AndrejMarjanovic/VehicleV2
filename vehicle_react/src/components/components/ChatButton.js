import React from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faComment } from '@fortawesome/free-solid-svg-icons';

const ChatButton = ({ onClick }) => {
  return (
    <div className="chat-button" onClick={onClick}>
      <FontAwesomeIcon icon={faComment} className="chat-icon" />
    </div>
  );
};

export default ChatButton;