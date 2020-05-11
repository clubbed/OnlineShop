import React, { useEffect, useState } from "react";
import { getMyOrders } from "../../services/orderService";

function OrdersPage() {
  const [orders, setOrders] = useState([]);

  useEffect(() => {
    getMyOrders().then((data) => {
      setOrders({ ...orders, orders: orders.concat(data) });
      console.log("data", data);
    });
  }, []);

  const ordersData = (
    <div>
      {orders.length > 0 ? <div> orders</div> : <p>There is no order atm.</p>}
    </div>
  );

  return (
    <div>
      {ordersData}
      {orders.length}
    </div>
  );
}

export default OrdersPage;
