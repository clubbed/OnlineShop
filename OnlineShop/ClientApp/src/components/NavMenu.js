import React from "react";
import { Link } from "react-router-dom";
import { connect } from "react-redux";
import { logOut } from "../store/Auth";

function NavMenu({ roles, isAuthenticated, logOut }) {
  const guestLinks = (
    <ul className="nav-menu">
      <li>
        <Link to="/">Home</Link>
      </li>
      <li>
        <Link to="/login">Login</Link>
      </li>
      <li>
        <Link to="/register">Register</Link>
      </li>
    </ul>
  );

  const userLinks = (
    <ul className="navbar-nav">
      <li className="nav-item active">
        <Link to="/" className="nav-link">
          Home <span className="sr-only">(current)</span>
        </Link>
      </li>
      {roles !== undefined && roles.includes("Admin") && (
        <li className="nav-item">
          <Link to="/admin  " className="nav-link">
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
    <header>
      <nav className="navbar navbar-expand-lg navbar-light bg-light">
        <h2 className="logo">Online Shop</h2>
        {isAuthenticated ? userLinks : guestLinks}
      </nav>
    </header>
  );
}

function mapStateToProps(state) {
  return {
    isAuthenticated: state.auth.isAuthenticated,
    roles: state.auth.roles,
  };
}

export default connect(mapStateToProps, { logOut })(NavMenu);
