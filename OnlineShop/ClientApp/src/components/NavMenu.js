import React from "react";
import { Link } from "react-router-dom";
import { connect } from "react-redux";
import { logOut } from "../store/Auth";
import { Navbar, Nav } from "react-bootstrap";

function NavMenu({ roles, isAuthenticated, logOut }) {
  const guestLinks = (
    <ul className="navbar-nav mr-auto">
      <li className="nav-item">
        <Link to="/" className="nav-link">
          Home
        </Link>
      </li>
      <li className="nav-item">
        <Link to="/login">Login</Link>
      </li>
      <li className="nav-item">
        <Link to="/register">Register</Link>
      </li>
    </ul>
  );

  const userLinks = (
    <ul className="navbar-nav mr-auto">
      <li className="nav-item active">
        <Link to="/" className="nav-link">
          Home <span className="sr-only">(current)</span>
        </Link>
      </li>
      <li>
        <Link to="/cart" className="nav-link">
          Cart
        </Link>
      </li>
      <li>
        <Link to="/orders" className="nav-link">
          My Orders
        </Link>
      </li>
      {roles !== undefined && roles.includes("Admin") && (
        <li className="nav-item">
          <Link to="/admin" className="nav-link">
            Admin
          </Link>
        </li>
      )}
      <li className="nav-item">
        <a className="nav-link" style={{ cursor: "pointer" }} onClick={logOut}>
          Log OUT
        </a>
      </li>
    </ul>
  );

  return (
    <React.Fragment>
      <Navbar bg="light" expand="lg">
        <Navbar.Brand href="#home">Online Shop</Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          {isAuthenticated ? userLinks : guestLinks}
        </Navbar.Collapse>
      </Navbar>
    </React.Fragment>
  );
}

function mapStateToProps(state) {
  return {
    isAuthenticated: state.auth.isAuthenticated,
    roles: state.auth.roles,
  };
}

export default connect(mapStateToProps, { logOut })(NavMenu);
