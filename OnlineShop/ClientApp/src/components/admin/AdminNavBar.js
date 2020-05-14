import React from "react";
import { Link } from "react-router-dom";

const AdminNavBar = () => {
  return (
    <nav aria-label="breadcrumb">
      <ol className="breadcrumb">
        <Link to="/admin/products" className="breadcrumb-item">
          Products
        </Link>
        <Link to="/admin/vendors" className="breadcrumb-item">
          Vendors
        </Link>
        <Link to="/admin/measureunits" className="breadcrumb-item">
          Measure Units
        </Link>
        <Link to="/admin/shipment" className="breadcrumb-item">
          Shipment
        </Link>
        <Link to="/admin/orders" className="breadcrumb-item">
          Orders
        </Link>
        <Link to="/" className="breadcrumb-item">
          Home
        </Link>
      </ol>
    </nav>
  );
};

export default AdminNavBar;
