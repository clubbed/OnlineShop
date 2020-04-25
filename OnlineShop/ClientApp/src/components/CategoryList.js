import React, { useState, useEffect } from "react";
import { getAllCategories } from "../store/Category";

import { connect } from "react-redux";
import { Link } from "react-router-dom";
const CategoryList = ({
  withinCategory,
  categories,
  getAllCategories,
  products,
}) => {
  // const [categories, setCategories] = useState([]);

  useEffect(() => {
    if (categories.length === 0) {
      getAllCategories();
    }
  }, []);

  return (
    <ul className="list-group">
      {categories.length > 0 ? (
        categories.map((cat) => {
          return (
            <Link
              key={cat.id}
              to={{
                pathname: `category/${cat.id}`,
                // products: products.filter((c) => c.categoryId == cat.id),
              }}
            >
              <li className="list-group-item">{cat.name}</li>
            </Link>
          );
        })
      ) : (
        <li>No categories</li>
      )}
    </ul>
  );
};

function mapStateToProps(state) {
  return {
    categories: state.category.categories,
  };
}

export default connect(mapStateToProps, { getAllCategories })(CategoryList);
