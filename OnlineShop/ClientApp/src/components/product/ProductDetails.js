import React, { useEffect, useState } from "react";
import BackButton from "../common/BackButton";
import Spinner from "../common/Spinner";
import { getProductById } from "../../services/productService";

const ProductDetails = (props) => {
  const [product, setProduct] = useState({});
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const id = props.match.params.id;

    getProductById(id).then((product) => {
      console.log("product", product);
      setProduct(product);
      setLoading(false);
    });
  }, []);

  const productDetail = (
    <React.Fragment>
      <h2 className="text-center">{product.name}</h2>
      <p className="lead">{product.description}</p>
      <div className="alert alert-warning">
        Measure Unit - {product.measureUnit}, Price - {product.price}
      </div>
    </React.Fragment>
  );

  return (
    <div className="col-md-8 col-md-offset-2">
      <BackButton goBack={() => props.history.goBack()} />
      {loading ? <Spinner /> : productDetail}
    </div>
  );
};

export default ProductDetails;
