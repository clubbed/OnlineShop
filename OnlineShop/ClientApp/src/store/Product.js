import * as service from "../services/productService";

const GET_ALL_PRODUCTS_SUCCESS = "GET_ALL_PRODUCTS_SUCCESS";
const GET_ALL_PRODUCTS_ERROR = "GET_ALL_PRODUCTS_ERROR";
const GET_PRODUCT_BY_ID_SUCCESS = "GET_PRODUCT_BY_ID_SUCCESS";

function getAllProductsSuccess(data) {
  return {
    type: GET_ALL_PRODUCTS_SUCCESS,
    payload: data,
  };
}

function getAllProductsError(data) {
  return {
    type: GET_ALL_PRODUCTS_ERROR,
    payload: data,
  };
}

function getProductByIdSuccess(data) {
  return {
    type: GET_PRODUCT_BY_ID_SUCCESS,
    payload: data,
  };
}

export const getProductById = (id) => (dispatch) => {
  service
    .getProductById(id)
    .then((product) => dispatch(getProductByIdSuccess(product)));
};

export const getAllProducts = () => (dispatch) => {
  service.getAllProducts().then((products) => dispatch(products));
};

const initialState = {
  products: [],
};

export const reducer = (state, action) => {
  switch (action.type) {
    case GET_ALL_PRODUCTS_SUCCESS:
      return { ...state, products: action.payload };
    default:
      return state;
  }
};
