import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import * as service from "../../../services/orderService";

const OrderListPage = () => {
  const [orders, setOrders] = useState([]);

  useEffect(() => {
    service.getAllOrders().then((response) => {
      setOrders(response.data.data);
    });
  }, []);

  const showOrders =
    orders.length > 0
      ? orders.map((od) => (
          <tr key={od.id}>
            <td>{od.id}</td>
            <td>{od.customer}</td>
            <td>{od.total}</td>
            <td>
              <Link
                to={{
                  pathname: `/admin/order/${od.id}`,
                  state: {
                    order: od,
                  },
                }}
                className="btn btn-warning"
              >
                Details
              </Link>
            </td>
          </tr>
        ))
      : null;
  return (
    <div>
      <h2>Orders</h2>
      <table className="table">
        <thead>
          <tr>
            <th>Id</th>
            <th>Customer</th>
            <th>Total</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>{showOrders}</tbody>
      </table>
    </div>
  );
};

export default OrderListPage;
