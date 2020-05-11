import React from "react";
import { Redirect } from "react-router-dom";
import { connect } from "react-redux";

const CheckOutPage = ({ items, total }) => {
  return items.length > 0 ? (
    <div className="col-md-6 col-md-offset-3">
      <div className="text-center">
        <h1>Check out</h1>
      </div>
      <hr />
      <div>
        {items &&
          items.map((c) => (
            <p className="lead">
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
        <button type="submit" className="btn btn-primary">
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
export default connect(mapStateToProps, null)(CheckOutPage);
