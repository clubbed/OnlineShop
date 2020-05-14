import React, { useEffect, useState } from "react";
import { getMyOrders } from "../../services/orderService";

function OrdersPage() {
  const [orders, setOrders] = useState([]);

  useEffect(() => {
    getMyOrders().then((response) => {
      setOrders(response.data);
      console.log("data", response.data);
    });
  }, []);

  const showOrders =
    orders.length > 0
      ? orders.map((od) => (
          <tr key={od.id}>
            <td>{od.id}</td>
            <td>{od.customer}</td>
            <td>{od.total}</td>
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
          </tr>
        </thead>
        <tbody>{showOrders}</tbody>
      </table>
    </div>
  );
}

export default OrdersPage;
