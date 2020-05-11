import React from "react";
import { connect } from "react-redux";
import { removeFromCart } from "../store/Cart";
import { Link } from "react-router-dom";

const CartPage = ({ items, total, removeFromCart }) => {
  var showItems = items.map((c) => {
    return (
      <tr key={c.id}>
        <td>{c.name}</td>
        <td>{c.qty}</td>
        <td>{c.price}</td>
        <td>
          <input
            className="btn btn-sm btn-danger"
            defaultValue="Remove"
            onClick={() => {
              removeFromCart(c.id);
            }}
          />
        </td>
      </tr>
    );
  });

  var showTotal = total && <div>Total: {total}</div>;

  return (
    <div>
      {items && (
        <table className="table table-bordered">
          <thead>
            <tr>
              <th>Name</th>
              <th>Qty</th>
              <th>Price</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody>{showItems}</tbody>
          <tfoot>
            <tr>
              <td colSpan="3"></td>
              <td>
                <strong>
                  Total:
                  {total && showTotal}
                </strong>
              </td>
            </tr>
          </tfoot>
        </table>
      )}
      {items.length && (
        <div className="ml-auto">
          <Link className="btn btn-primary" to="/checkout">
            Check out
          </Link>
        </div>
      )}
    </div>
  );
};

function mapStateToProps(state) {
  return {
    items: state.cart.items,
    total: state.cart.total,
  };
}

export default connect(mapStateToProps, { removeFromCart })(CartPage);
