import axios from "axios";

const getAllProducts = (page, size) => {
  const config = {
    headers: {
      Authorization: `Bearer ${localStorage.token}`,
    },
  };
  return axios
    .get(`/api/product?pageNumber=${page}&pageSize=${size}`, config)
    .then((success) => success.data)
    .catch((err) => err.response);
};

const getFeatured = () => {
  const config = {
    headers: {
      Authorization: `Bearer ${localStorage.token}`,
    },
  };
  return axios.get("/api/product/featured", config).then(
    (success) => {
      console.log("data", success);
      return success.data.data;
    },
    (err) => err.data
  );
};

const getProductById = (id) => {
  const config = {
    headers: {
      Authorization: `Bearer ${localStorage.token}`,
    },
  };
  return axios.get(`/api/product/${id}`, config).then(
    (success) => success.data.data,
    (err) => err.data
  );
};

const getProductsByCategory = (data) => {
  return axios.get(
    `/api/product/category?id=${data.id}&pageNumber=${data.pageNumber}&pageSize=${data.pageSize}`
  );
};

const createProduct = (data) => {
  const config = {
    headers: {
      "Content-Type": "multipart/form-data",
      Authorization: `Bearer ${localStorage.token}`,
    },
  };

  // return axios.post("/api/product/create", data, config).then(
  //   (success) => success.data,
  //   (err) => err.data
  // );
  // console.log("create product form data", data);
  return axios({
    url: "/api/product/create",
    method: "POST",
    headers: {
      "Content-Type": "multipart/form-data",
      Authorization: `Bearer ${localStorage.token}`,
    },
    data: data,
  });
  // .then((res) => console.log("image respon", res))
  // .catch((err) => console.log("image err", err.response));
};

export {
  getAllProducts,
  getProductById,
  createProduct,
  getFeatured,
  getProductsByCategory,
};
