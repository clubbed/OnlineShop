import React, { useState, useEffect } from "react";
import { Redirect } from "react-router-dom";
import { connect } from "react-redux";
import * as service from "../../services/orderService";
import { emptyCart } from "../../store/Cart";

const CheckOutPage = ({ items, total, emptyCart, history }) => {
  console.log("items", items);
  const [order, setOrder] = useState({
    total: 0,
    orderDetails: [],
  });

  useEffect(() => {
    setOrder({
      total: total,
      orderDetails: items.map((item) => ({
        productId: item.id,
        productName: item.name,
        qty: item.qty,
        price: item.price,
        taxId: 3,
        discount: 0,
      })),
    });
  }, []);

  const submitOrder = () => {
    service.createOrder(order).then((response) => {
      if (response.status === 200) {
        emptyCart();
        history.push("/");
      }
    });
  };
  return items.length > 0 ? (
    <div className="col-md-6 col-md-offset-3">
      <div className="text-center">
        <h1>Check out</h1>
      </div>
      <hr />
      <div>
        {items &&
          items.map((c) => (
            <p className="lead" key={c.id}>
              {c.name}({c.qty}) - {c.price}$
            </p>
          ))}
        Amount to be paid: {total}$
      </div>
      <div>
        <select className="form-control">
          <option>Kesh</option>
          <option>Kredit Kart</option>
          <option>Paypal</option>
        </select>
      </div>
      <div className="text-center mt-5">
        <button type="submit" className="btn btn-primary" onClick={submitOrder}>
          Confirm
        </button>
        <button className="btn btn-danger">Cancel</button>
      </div>
    </div>
  ) : (
    <Redirect to={{ pathname: "/cart" }} />
  );
};

function mapStateToProps(state) {
  return {
    items: state.cart.items,
    total: state.cart.total,
  };
}
export default connect(mapStateToProps, { emptyCart })(CheckOutPage);
