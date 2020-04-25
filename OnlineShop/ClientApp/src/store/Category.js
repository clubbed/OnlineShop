import axios from "axios";

const GET_ALL_CATEGORIES = "GET_ALL_CATEGORIES";

const getAllCategoriesSuccess = (data) => {
  return {
    type: GET_ALL_CATEGORIES,
    payload: data,
  };
};

export const getAllCategories = () => (dispatch) => {
  axios.get("/api/category").then(
    (success) => dispatch(getAllCategoriesSuccess(success.data.data)),
    (err) => err.data
  );
};

const initialState = {
  categories: [],
};

export const reducer = (state = initialState, action) => {
  switch (action.type) {
    case GET_ALL_CATEGORIES:
      return { ...state, categories: action.payload };
    default:
      return state;
  }
};
