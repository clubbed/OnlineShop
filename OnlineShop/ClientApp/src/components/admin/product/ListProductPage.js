import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import * as service from "../../../services/productService";

const ListProductPage = () => {
  const [products, setProducts] = useState({});

  useEffect(() => {
    service.getAllProducts(1, 10).then((data) => {
      console.log("prods list", data);
      setProducts(data);
    });
  }, []);

  const showProducts = products.data ? (
    products.data.map((p) => (
      <tr key={p.id}>
        <td>{p.id}</td>
        <td>{p.name}</td>
        <td>{p.description}</td>
        <td>{p.price}</td>
        <td>{p.qty}</td>
        <td>{p.categoryName}</td>
        <td>{p.measureUnit}</td>
        <td>{p.vendor}</td>
        <td>{p.isFeatured}</td>
        <td></td>
        {/* <td><img src={p.imagePath} /></td> */}
        <td>{p.active}</td>
        <td>
          <Link
            to={{
              pathname: `/admin/products/edit/${p.id}`,
              state: { product: p },
            }}
            className="btn btn-warning"
          >
            Edit
          </Link>

          <Link
            to={`/admin/products/delete/${p.id}`}
            className="btn btn-danger"
          >
            Delete
          </Link>
        </td>
      </tr>
    ))
  ) : (
    <tr className="text-center">
      <td colSpan="10">There is no products atm</td>
    </tr>
  );

  return (
    <div>
      <div className="row mb-4">
        <div className="btn-group">
          <Link to="/admin/products/create" className="btn btn-primary">
            Create
          </Link>
        </div>
      </div>
      <div className="row">
        <table className="table">
          <thead className="bg-primary">
            <tr>
              <th>Id</th>
              <th>Name</th>
              <th>Description</th>
              <th>Price</th>
              <th>Qty</th>
              <th>Category</th>
              <th>Measure Unit</th>
              <th>Vendor</th>
              <th>Is Featured</th>
              <th>Photo</th>
              <th>Active</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>{showProducts}</tbody>
        </table>
      </div>
    </div>
  );
};

export default ListProductPage;
