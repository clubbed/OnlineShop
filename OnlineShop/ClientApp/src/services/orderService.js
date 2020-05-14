import axios from "axios";

const getMyOrders = () => {
  const config = {
    headers: {
      Authorization: `Bearer ${localStorage.token}`,
    },
  };

  return axios
    .get("/api/order/getmyorders", config)
    .then((success) => {
      console.log("success order", success);
      return success.data;
    })
    .catch((err) => err.response);
};

const getAllOrders = () => {
  const config = {
    headers: {
      Authorization: `Bearer ${localStorage.token}`,
    },
  };

  return axios.get("/api/order", config);
};

const createOrder = (data) => {
  const config = {
    headers: {
      Authorization: `Bearer ${localStorage.token}`,
    },
    data: data,
  };
  console.log("config", config);

  // return axios.post("/api/order", config);
  return axios({
    url: "/api/order",
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${localStorage.token}`,
    },
    data: data,
  });
};

export { getMyOrders, getAllOrders, createOrder };
