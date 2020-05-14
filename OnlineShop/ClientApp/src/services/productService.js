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
    url: "/api/product",
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

const updateProduct = (data) => {
  const config = {
    headers: {
      "Content-Type": "multipart/form-data",
      Authorization: `Bearer ${localStorage.token}`,
    },
    data: data,
  };

  return axios.delete(`/api/product?id=${data.id}`, config);
};

const deleteProduct = (id) => {
  const config = {
    headers: {
      "Content-Type": "multipart/form-data",
      Authorization: `Bearer ${localStorage.token}`,
    },
  };

  return axios.delete(`/api/product?id=${id}`, config);
};

const getMeasureUnits = () => {
  const config = {
    headers: {
      "Content-Type": "multipart/form-data",
      Authorization: `Bearer ${localStorage.token}`,
    },
  };

  return axios.get("/api/measureunit", config);
};

const getVendors = () => {
  const config = {
    headers: {
      "Content-Type": "multipart/form-data",
      Authorization: `Bearer ${localStorage.token}`,
    },
  };

  return axios.get("/api/vendor", config);
};

const getCategories = () => {
  const config = {
    headers: {
      "Content-Type": "multipart/form-data",
      Authorization: `Bearer ${localStorage.token}`,
    },
  };

  return axios.get("/api/category", config);
};

const getShippingTypes = () => {
  const config = {
    headers: {
      "Content-Type": "multipart/form-data",
      Authorization: `Bearer ${localStorage.token}`,
    },
  };

  return axios.get("/api/shippingtypes", config);
};

export {
  getAllProducts,
  getProductById,
  createProduct,
  deleteProduct,
  updateProduct,
  getFeatured,
  getProductsByCategory,
  getMeasureUnits,
  getVendors,
  getShippingTypes,
  getCategories,
};
