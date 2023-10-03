import React, { useState } from 'react';
import { observer, inject } from 'mobx-react';
import { Navbar, Nav, OverlayTrigger } from 'react-bootstrap';
import { Link, useLocation } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBars, faTimes, faUser, faSignOutAlt, faEdit, faHome, faKey } from '@fortawesome/free-solid-svg-icons';

const VehicleNavbar = ({ rootStore }) => {
  const location = useLocation();

  const [isMenuOpen, setIsMenuOpen] = useState(false);
  const [isUserPopoverOpen, setIsUserPopoverOpen] = useState(false);

  const handleToggleMenu = () => {
    setIsMenuOpen(!isMenuOpen);
  };

  const handleToggleUserPopover = () => {
    setIsUserPopoverOpen(!isUserPopoverOpen);
  };

  const handleLogout = () => {
    rootStore.authStore.clearAuthData();
    setIsUserPopoverOpen(false);
  };

  const username = rootStore.authStore.getUsername();

  const userPopover = (
    <div id="user-popover" className={isUserPopoverOpen ? 'open' : ''}>
      <div className="user-dropdown">
        <div className="dropdown-title">{username}</div>
        < div className='dropdown-item'>
        </div>
        <div className="dropdown-item">
          <Link className="account-link custom-link" to="/account">
            <FontAwesomeIcon icon={faEdit} className="icon-left" />
            Update account
          </Link>
        </div>
        <div className="dropdown-item">
          <Link className="password-link custom-link" to="/update-password">
            <FontAwesomeIcon icon={faKey} className="icon-left" />
            Change Password
          </Link>
        </div>
        <div className="dropdown-item">
          <Nav.Link className="logout-link" href="/" onClick={handleLogout}>
            <FontAwesomeIcon icon={faSignOutAlt} className="icon-left" />
            Sign out
          </Nav.Link>
        </div>
      </div>
    </div>
  );

  const navbarToggler = (
    <div id="user-popover" className={isMenuOpen ? 'open' : ''}>
      <div className="user-dropdown">
        <div className="dropdown-item">
        <Link className='custom-link' to="/vehiclemake">Vehicle make</Link>
        </div>
        <div className="dropdown-item">
        <Link className='custom-link' to="/vehiclemodel">Vehicle model</Link>
        </div>
      </div>
    </div>
  );

  return (
    <div className="VehicleNavbar">
      <Navbar className="navbar navbar-expand-lg" bg="light">
        <Nav className="nav">
          <OverlayTrigger
            trigger="click"
            placement="bottom"
            overlay={navbarToggler}
            onEntered={() => setIsMenuOpen(true)}
            onExited={() => setIsMenuOpen(false)}
          >
            <Link className={`navbar-toggler ${isMenuOpen ? 'open' : ''}`} onClick={handleToggleMenu}>
              <FontAwesomeIcon icon={isMenuOpen ? faTimes : faBars} title={username} />
            </Link>
          </OverlayTrigger>
          <Link className={location.pathname === '/homepage' ? 'active-link custom-link' : 'custom-link'} to="/homepage"> <FontAwesomeIcon icon={faHome} /> </Link>
          <Link className={location.pathname === '/vehiclemake' ? 'make-link active-link custom-link' : 'make-link custom-link'} to="/vehiclemake">Vehicle make</Link>
          <Link className={location.pathname === '/vehiclemodel' ? 'model-link active-link custom-link' : 'model-link custom-link'} to="/vehiclemodel">Vehicle model</Link>
          <OverlayTrigger
            trigger="click"
            placement="bottom"
            overlay={userPopover}
            onEntered={() => setIsUserPopoverOpen(true)}
            onExited={() => setIsUserPopoverOpen(false)}
          >
            <Link className={`user-link ${isUserPopoverOpen ? 'active' : ''}`} onClick={handleToggleUserPopover}>
              <FontAwesomeIcon icon={faUser} title={username} />
            </Link>
          </OverlayTrigger>
        </Nav>
      </Navbar>
    </div>
  );
};

export default inject('rootStore')(observer(VehicleNavbar));