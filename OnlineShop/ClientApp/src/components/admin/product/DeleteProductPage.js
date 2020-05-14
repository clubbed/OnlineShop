import React from "react";
import * as service from "../../../services/productService";
import BackButton from "../../common/BackButton";

const DeleteProductPage = (props) => {
  const { id } = props.match.params;

  const deleteProd = () => {
    service.deleteProduct(id).then((success) => {
      props.history.goBack();
    });
  };
  return (
    <div>
      <h2>
        Are you sure you want to remove product with id ={" "}
        {props.match.params.id}
      </h2>
      <BackButton goBack={() => props.history.goBack()} />
      <button type="button" className="btn btn-danger" onClick={deleteProd}>
        Delete
      </button>
    </div>
  );
};

export default DeleteProductPage;
