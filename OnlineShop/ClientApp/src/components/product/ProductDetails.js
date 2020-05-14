import React, { useEffect, useState } from "react";
import BackButton from "../common/BackButton";
import Spinner from "../common/Spinner";
import { getProductById } from "../../services/productService";
import { connect } from "react-redux";
import { addToCart } from "../../store/Cart";

const ProductDetails = (props) => {
  const [product, setProduct] = useState({});
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const id = props.match.params.id;

    getProductById(id).then((product) => {
      setProduct(product);
      setLoading(false);
    });
  }, []);

  const addToCart = () => {
    props.addToCart(product);
  };

  const productDetail = (
    <React.Fragment>
      <h2 className="text-center">{product.name}</h2>
      <p className="lead">{product.description}</p>
      <div className="alert alert-warning">
        Measure Unit - {product.measureUnit}, Price - {product.price}
      </div>
      {props.isAuthenticated && (
        <div>
          <button className="btn btn-primary" onClick={addToCart}>
            Add to Cart
          </button>
        </div>
      )}
    </React.Fragment>
  );

  return (
    <div>
      <BackButton goBack={() => props.history.goBack()} />
      {loading ? <Spinner /> : productDetail}
    </div>
  );
};

function mapStateToProps(state) {
  return {
    isAuthenticated: state.auth.isAuthenticated,
  };
}

export default connect(mapStateToProps, { addToCart })(ProductDetails);
