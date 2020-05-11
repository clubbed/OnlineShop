import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import * as productService from "../services/productService";
import ProductCard from "./product/ProductCard";
import { Link } from "react-router-dom";
import Spinner from "./common/Spinner";
import CategoryList from "./CategoryList";
import Pagination from "./common/Pagination";

const Home = (props) => {
  const [state, setState] = useState({
    products: [],
    categories: [],
    loading: false,
  });
  const [totalPages, setTotalPages] = useState(0);
  const [hasPrevious, setHasPrevious] = useState(false);
  const [hasNext, setHasNext] = useState(false);
  const [currentPage, setCurrentPage] = useState(1);
  const [featuredProducts, setFeaturedProducts] = useState([]);

  const loadAllProducts = (page, size) => {
    console.log("page", page);
    console.log("size", size);

    setState({ ...state, loading: true });
    productService
      .getAllProducts(page, size)
      .then((response) => {
        console.log("repsonse all", response);
        setState({
          ...state,
          products: state.products.concat(response.data),
          loading: false,
        });
        setTotalPages(response.totalPages);
        setHasNext(response.hasNextPage);
        setHasPrevious(response.hasPreviousPage);
        setCurrentPage(response.pageIndex);
      })
      .catch((err) => console.log("err", err));
  };

  useEffect(() => {
    setState({ ...state, loading: true });
    productService.getFeatured().then((response) => {
      if (response !== undefined) {
        // setState({ products: response.data, loading: false });
        setFeaturedProducts(featuredProducts.concat(response.data));
        setState({ ...state, loading: false });
        // setTotalPages(response.totalPages);
      }
      setState({ ...state, loading: false });
    });

    loadAllProducts(1, 10);
    console.log("state products length", state.products.length);
  }, []);

  const products =
    state.products.length > 0 ? (
      state.products.map((value) => {
        return (
          <Link key={value.id} to={`/product/${value.id}`}>
            <ProductCard key={value.id} product={value} />
          </Link>
        );
      })
    ) : (
      <p>No products</p>
    );

  return (
    <div className="container">
      <h1 className="text-center">Welcome to our shop!</h1>
      <hr />
      <div className="col-md-3">
        {/* <CategoryList products={state.products} /> */}
        <CategoryList />
      </div>
      <div className="col-md-9">
        {state.loading ? <Spinner /> : products}
        {totalPages > 1 && (
          <Pagination
            currentPage={currentPage}
            totalPages={totalPages}
            loadAllProducts={loadAllProducts}
            hasNext={hasNext}
            hasPrevious={hasPrevious}
          />
        )}
      </div>
    </div>
  );
};

export default connect()(Home);
