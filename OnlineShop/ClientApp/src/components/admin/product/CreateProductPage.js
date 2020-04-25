import React, { useState } from "react";
import * as productService from "../../../services/productService";

const CreateProductPage = () => {
  const [product, setProduct] = useState({
    name: "",
    description: "",
    price: 2,
    qty: 1,
    measureUnit: 1,
    vendor: 1,
    image: null,
  });

  const [errors, setErrors] = useState({});

  const onchange = (e) => {
    setProduct({
      ...product,
      [e.target.name]: e.target.value,
    });
  };

  const onFileChange = (e) => {
    setProduct({
      ...product,
      image: e.target.files[0],
    });
  };

  const onsubmit = (e) => {
    e.preventDefault();
    console.log("e.target", e.target);
    console.log("product", product);
    console.log("product pic", product.image);
    var formData = new FormData();
    formData.append("Name", product.name);
    formData.append("Description", product.description);
    formData.append("measureUnit", product.measureUnit);
    formData.append("price", product.price);
    formData.append("qty", product.qty);
    formData.append("vendor", product.vendor);
    formData.append("Image", product.image);

    for (var value of formData.values()) console.log("value", value);
    // console.log("formdata", formData);
    productService.createProduct(formData).then(
      (res) => console.log("res", res),
      (err) => {
        setErrors({ ...errors, data: err.response.data });
        console.log("err", err.response);
        console.log("errrrors", errors);
      }
    );
  };

  return (
    <div className="container">
      {errors && <div className="text-danger">{errors.data}</div>}
      <form encType="multipart/form-data" onSubmit={(e) => onsubmit(e)}>
        <label>Name:</label>
        <input
          type="text"
          name="name"
          className="form-control"
          onChange={onchange}
        />
        <label>Description:</label>
        <input
          type="text"
          name="description"
          className="form-control"
          onChange={onchange}
        />
        <label>Price:</label>
        <input
          type="number"
          name="price"
          className="form-control"
          onChange={onchange}
        />
        <label>Qty:</label>
        <input
          type="number"
          name="qty"
          className="form-control"
          onChange={onchange}
        />
        <label>MeasureUnit:</label>
        <input
          type="text"
          name="measureUnit"
          className="form-control"
          value="1"
          readOnly
        />
        <label>Vendor:</label>
        <input
          type="text"
          name="vendor"
          className="form-control"
          value="1"
          readOnly
        />
        <label>Image:</label>
        <input
          type="file"
          name="image"
          className="form-control"
          onChange={onFileChange}
        />
        <button type="submit" className="btn btn-success">
          Krijo produktin
        </button>
      </form>
    </div>
  );
};

export default CreateProductPage;
