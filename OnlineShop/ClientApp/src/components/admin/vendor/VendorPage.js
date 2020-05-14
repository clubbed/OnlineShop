import React, { useState, useEffect } from "react";
import * as service from "../../../services/productService";

const VendorPage = () => {
  const [vendors, setVendors] = useState([]);

  useEffect(() => {
    service.getVendors().then((response) => {
      console.log("response", response.data);
      setVendors(response.data);
    });
  }, []);

  const showVendors =
    vendors.length > 0
      ? vendors.map((v) => (
          <tr key={v.id}>
            <td>{v.id}</td>
            <td>{v.firstName}</td>
            <td>{v.lastName}</td>
            <td>{v.address}</td>
            <td>{v.city}</td>
            <td>{v.state}</td>
            <td>{v.tax}</td>
            <td>{v.discount}</td>
          </tr>
        ))
      : null;

  return (
    <div>
      <table className="table">
        <thead className="bg-danger">
          <tr>
            <th>Id</th>
            <th>First name</th>
            <th>Last name</th>
            <th>Address</th>
            <th>City</th>
            <th>State</th>
            <th>Tax type</th>
            <th>Discount</th>
          </tr>
        </thead>
        <tbody>{showVendors}</tbody>
      </table>
    </div>
  );
};

export default VendorPage;
