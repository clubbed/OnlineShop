import React, { useState, useEffect } from "react";
import BackButton from "../../common/BackButton";
import * as productService from "../../../services/productService";
import { Modal, Button } from "react-bootstrap";

const CreateProductPage = (props) => {
  const [product, setProduct] = useState({
    name: "",
    description: "",
    price: 2,
    qty: 1,
    measureUnit: null,
    vendor: "",
    category: null,
    isFeatured: false,
    active: false,
    image: null,
  });

  const [measureUnits, setMeasureUnits] = useState([]);
  const [vendors, setVendors] = useState([]);
  const [categories, setCategories] = useState([]);

  useEffect(() => {
    productService.getMeasureUnits().then((response) => {
      setMeasureUnits(response.data);
    });

    productService.getVendors().then((response) => {
      setVendors(response.data);
    });

    productService.getCategories().then((response) => {
      setCategories(response.data.data);
    });
  }, []);

  const [modal, setModal] = useState({
    open: false,
    body: "",
  });
  const [errors, setErrors] = useState({});

  const onchange = (e) => {
    setProduct({
      ...product,
      [e.target.name]: e.target.value,
    });
  };

  const onCheckBox = (e) => {
    setProduct({
      ...product,
      [e.target.name]: e.target.checked,
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

    if (product.category == null) {
      alert("please select a category");
      return false;
    }

    if (product.measureUnit == null) {
      alert("please select a measureUnit");
      return false;
    }

    if (product.vendor == null) {
      alert("please select a vendor");
      return false;
    }

    var formData = new FormData();
    formData.append("Name", product.name);
    formData.append("Description", product.description);
    formData.append("measureUnit", product.measureUnit);
    formData.append("price", product.price);
    formData.append("qty", product.qty);
    formData.append("vendor", product.vendor);
    formData.append("category", product.category);
    formData.append("Image", product.image);

    productService.createProduct(formData).then(
      (res) => {
        console.log("res", res);
        setModal({
          open: true,
          body: res.data.message,
        });
      },
      (err) => {
        setErrors({ ...errors, data: err.response.data });
      }
    );
  };

  const modalShow = (
    <Modal show={modal.open}>
      <Modal.Header>
        <Modal.Title>Message</Modal.Title>
      </Modal.Header>

      <Modal.Body className="text-center">
        <p>{modal.body}</p>
      </Modal.Body>

      <Modal.Footer>
        <Button
          variant="danger"
          onClick={() => {
            setModal({ ...modal, open: false });
            props.history.goBack();
          }}
        >
          Close
        </Button>
      </Modal.Footer>
    </Modal>
  );

  return (
    <div className="container">
      {errors && <div className="text-danger">{errors.data}</div>}
      {modalShow}
      <BackButton goBack={() => props.history.goBack()} />
      <form encType="multipart/form-data" onSubmit={(e) => onsubmit(e)}>
        <div className="form-group">
          <label>Name:</label>
          <input
            type="text"
            name="name"
            className="form-control"
            onChange={onchange}
          />
        </div>

        <div className="form-group">
          <label>Description:</label>
          <input
            type="text"
            name="description"
            className="form-control"
            onChange={onchange}
          />
        </div>

        <div className="form-group">
          <label>Price:</label>
          <input
            type="number"
            name="price"
            step="0.01"
            className="form-control"
            onChange={onchange}
          />
        </div>

        <div className="form-group">
          <label>Qty:</label>
          <input
            type="number"
            name="qty"
            className="form-control"
            onChange={onchange}
          />
        </div>

        <div className="form-group">
          <label>Measure Unit:</label>
          <select
            name="measureUnit"
            className="form-control"
            onChange={onchange}
          >
            <option>Please select a measure unit</option>
            {measureUnits.map((m) => (
              <option value={m.id} key={m.id}>
                {m.name}
              </option>
            ))}
          </select>
        </div>

        <div className="form-group">
          <label>Category:</label>
          <select name="category" className="form-control" onChange={onchange}>
            <option>Please select a category</option>
            {categories.map((c) => (
              <option value={c.id} key={c.id}>
                {c.name}
              </option>
            ))}
          </select>
        </div>

        <div className="form-group">
          <label>Vendor:</label>
          <select name="vendor" className="form-control" onChange={onchange}>
            <option>Please select a vendor</option>
            {vendors.map((v) => (
              <option value={v.id} key={v.id}>
                {v.firstName} {v.lastName}
              </option>
            ))}
          </select>
        </div>

        <div className="form-group">
          <label>Image:</label>
          <input
            type="file"
            name="image"
            className="form-control"
            onChange={onFileChange}
          />
        </div>

        <div className="form-group">
          <label>Is Featured:</label>
          <input
            type="checkbox"
            name="isFeatured"
            checked={product.isFeatured}
            onChange={onCheckBox}
          />
          <label>Active:</label>
          <input
            type="checkbox"
            name="active"
            checked={product.active}
            onChange={onCheckBox}
          />
        </div>
        <div className="form-group">
          <button type="submit" className="btn btn-success">
            Krijo produktin
          </button>
        </div>
      </form>
    </div>
  );
};

export default CreateProductPage;
