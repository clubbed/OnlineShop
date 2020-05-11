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

export { getMyOrders };
