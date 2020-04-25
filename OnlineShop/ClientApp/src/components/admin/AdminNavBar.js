import React from "react";
import { Link } from "react-router-dom";

const AdminNavBar = () => {
  return (
    <nav aria-label="breadcrumb">
      <ol className="breadcrumb">
        <Link to="/admin/products" className="breadcrumb-item">
          <a href="#">Products</a>
        </Link>
        <Link to="/admin/vendors" className="breadcrumb-item">
          <a href="#">Library</a>
        </Link>
        <Link to="/admin/measureunits" className="breadcrumb-item">
          <a href="#">Measure Units</a>
        </Link>
        <Link to="/admin/shipment" className="breadcrumb-item">
          <a href="#">Shipment</a>
        </Link>
        <Link to="/admin/vendors" className="breadcrumb-item">
          <a href="#">Library</a>
        </Link>
        <li className="breadcrumb-item active" aria-current="page">
          Data
        </li>
      </ol>
    </nav>
  );
};

export default AdminNavBar;
