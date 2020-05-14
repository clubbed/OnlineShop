import React from "react";

const OrderDetailsPage = (props) => {
  console.log("props details", props);
  const { order } = props.location.state;

  console.log("order", order);

  const showDetails =
    order.orderDetails.length > 0
      ? order.orderDetails.map((od) => (
          <tr key={od.productId}>
            <td>{od.productId}</td>
            <td>{od.productName}</td>
            <td>{od.price}</td>
            <td>{od.qty}</td>
            <td>{od.discount}</td>
            <td>{od.tax}</td>
          </tr>
        ))
      : null;

  return (
    <div>
      <h2>Order Details</h2>
      <table className="table">
        <thead>
          <tr>
            <th>Product Id</th>
            <th>Name</th>
            <th>Price</th>
            <th>Qty</th>
            <th>Discount</th>
            <th>Tax</th>
          </tr>
        </thead>
        <tbody>{showDetails}</tbody>
      </table>
    </div>
  );
};

export default OrderDetailsPage;
