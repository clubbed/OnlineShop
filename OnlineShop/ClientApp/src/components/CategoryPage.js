import React, { useEffect, useState } from "react";
import BackButton from "./common/BackButton";
import * as productService from "../services/productService";
import CategoryList from "./CategoryList";
import Pagination from "./common/Pagination";
import Spinner from "./common/Spinner";
import ProductCard from "./product/ProductCard";
import { Link } from "react-router-dom";

const CategoryPage = (props) => {
  const [categoryProducts, setCategoryProducts] = useState([]);
  const [loading, setLoading] = useState(false);
  const [totalPages, setTotalPages] = useState(0);
  const [hasPrevious, setHasPrevious] = useState(false);
  const [hasNext, setHasNext] = useState(false);
  const [currentPage, setCurrentPage] = useState(1);
  const [errorMessage, setErrorMessage] = useState("");

  const loadCategoryProducts = (pageNumber, pageSize) => {
    const data = {
      id: props.match.params.id,
      pageNumber,
      pageSize,
    };
    console.log("data", data);
    setLoading(true);

    productService.getProductsByCategory(data).then(
      (res) => {
        console.log("res", res);
        setCategoryProducts(categoryProducts.concat(res.data.data));
        setLoading(false);
        setTotalPages(res.data.totalPages);
        setHasNext(res.data.hasNextPage);
        setHasPrevious(res.data.hasPreviousPage);
        setCurrentPage(res.data.pageIndex);
      },
      (err) => {
        setLoading(false);
        console.log("err", err.response);
      }
    );
  };
  useEffect(() => {
    // const data = {
    //   id: props.match.params.id,
    //   pageNumber: 1,
    //   pageSize: 10,
    // };
    loadCategoryProducts(1, 10);
  }, []);

  const products =
    categoryProducts.length > 0 ? (
      categoryProducts.map((value) => {
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
      <BackButton goBack={() => props.history.goBack()} />
      <div className="col-md-3">
        <CategoryList />
      </div>
      <div className="col-md-9">
        {loading ? <Spinner /> : products}
        {totalPages > 1 && (
          <Pagination
            currentPage={currentPage}
            totalPages={totalPages}
            loadAllProducts={loadCategoryProducts}
            hasNext={hasNext}
            hasPrevious={hasPrevious}
          />
        )}
      </div>
    </div>
  );
};

export default CategoryPage;
