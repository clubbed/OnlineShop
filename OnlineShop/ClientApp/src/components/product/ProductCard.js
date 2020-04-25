import React from "react";
const Product = ({ product }) => {
  return (
    <div className="col-md-6 card">
      <img
        className="card-img-top"
        src="/images/coca-cola-classic.jpg"
        alt="Card image cap"
      ></img>
      <div className="card-body">
        <h3 className="card-title">{product.name}</h3>
        <p className="card-text">{product.description}</p>
        <span>Price: {product.price}$</span>
      </div>
    </div>
  );
};

export default Product;
